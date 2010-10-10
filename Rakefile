require 'rubygems'
require 'faster_csv'
require 'haml'
require 'ostruct'
require 'active_support/all'

module Mono
  Root = "/Libraries/Frameworks/Mono.framework"
  Gac = "#{Root}/Libraries/mono/gac"

  def self.install_assembly(assembly_file)
    system "sudo gacutil -i '#{assembly_file}'"
  end

  def self.uninstall_assembly(assembly_name)
    system "sudo gacutil -u '#{assembly_name}'"
  end
end

module Boo
  Root = 'Dependencies/boo'
  Build = "#{Root}/build"
  Lib = '/Library/Frameworks/Mono.framework/Versions/2.6.7/lib/boo'
  Assemblies = %W|Boo.Lang.CodeDom
    Boo.Lang.Compiler
    Boo.Lang
    Boo.Lang.Extensions
    Boo.Lang.Interpreter
    Boo.Lang.Parser
    Boo.Lang.PatternMatching
    Boo.Lang.Useful|
end

module MonoDevelop
  Root = 'Dependencies/monodevelop'
  Application = '/Applications/MonoDevelop.app/Contents/MacOS'
  Assemblies = %W|MonoDevelop.GtkCore|

  module Core
    Build = "#{MonoDevelop::Root}/main/build/bin"
    Assemblies = %W|Mono.TextEditor|
  end

  module AddIns
    Build = "#{MonoDevelop::Root}/main/build/AddIns"
    Lib = "#{MonoDevelop::Application}/lib/monodevelop/AddIns"
    Assemblies = %W|MonoDevelop.Gettext
    MonoDevelop.GtkCore|
  end

  module BooBinding
    Root = "#{MonoDevelop::Root}/extras/BooBinding"
    Build = "#{Root}/build"
  end

  def self.build(solution, options)
    configuration = options[:configuration]
    project = options[:project]
    system "#{Application}/mdtool build #{"-c:#{configuration}" if configuration} #{"-p:#{project}" if project} #{solution}"
  end
end

task :default => [:test]

desc 'Build Pantheon'
task :build do
  MonoDevelop::build 'Pantheon.sln', :configuration => 'release'
end

namespace :build do
  desc 'Build MonoDevelop'
  task :monodevelop do
    MonoDevelop::Assemblies.each do |assembly|
      MonoDevelop::build "#{MonoDevelop::Root}/main/Main.sln", :configuration => 'release', :project => assembly
    end
  end

  desc 'Build Boo'
  task :boo do
    cd Boo::Root do
      system 'nant'
    end
  end
end

namespace :install do
  desc 'Install MonoDevelop'
  task :monodevelop => [:'build:monodevelop'] do
    MonoDevelop::Core::Assemblies.each do |core_assembly|
      Mono::install_assembly "#{MonoDevelop::Core::Build}/#{core_assembly}.dll"
    end
  end

  namespace :monodevelop do
    desc 'Install addins'
    task :addins do
      MonoDevelop::AddIns::Assemblies.each do |addin|
        system "sudo cp -r #{MonoDevelop::AddIns::Build}/#{addin}/* '#{MonoDevelop::AddIns::Lib}/#{addin}/'"
      end
    end

    desc 'Install Boo binding'
    task :boo_binding => [:'install:monodevelop:addins'] do
      cd MonoDevelop::BooBinding::Root do
        system './configure'
        system 'make'
      end
      system "sudo mkdir -p '#{MonoDevelop::AddIns::Lib}/BooBinding/'"
      system "sudo cp -r #{MonoDevelop::BooBinding::Build}/* '#{MonoDevelop::AddIns::Lib}/BooBinding/'"
    end
  end

  desc 'Install Boo'
  task :boo => [:'uninstall:boo', :'build:boo'] do
    system "sudo mkdir -p '#{Boo::Lib}'"
    system "sudo cp #{Boo::Build}/*.exe* '#{Boo::Lib}/'"
    Boo::Assemblies.each do |assembly_name|
      Dir.glob "#{Boo::Build}/#{assembly_name}.dll" do |assembly_file|
        Mono::install_assembly assembly_file
      end
    end
  end

  namespace :boo do
    desc 'Fix Boo symlinks'
    task :fix_symlinks do
      Boo::Assemblies.each do |assembly_name|
        rm "#{Boo::Lib}/#{assembly_name}.dll"
        ln_s "#{Mono::Gac}/#{assembly_name}/*/#{assembly_name}.dll", "#{Boo::Lib}/#{assembly_name}.dll"
      end
    end
  end
end

desc 'Install Pantheon'
task :install => [:'install:boo', :'install:monodevelop:boo_binding', :build] do
end

namespace :uninstall do
  desc 'Uninstall Boo'
  task :boo do
    rm_rf "#{Boo::Lib}"
    Boo::Assemblies.each do |assembly_name|
      Mono::uninstall_assembly assembly_name
    end
  end
end

desc 'Uninstall Pantheon'
task :uninstall do
end

namespace :test do
  desc 'Test syntax'
  task :syntax do
    sh 'mono NUnit/nunit-console.exe Pantheon.Syntax.Test/bin/Debug/Pantheon.Syntax.Test.dll'
  end

  desc 'Test system'
  task :system do
    sh 'mono NUnit/nunit-console.exe Pantheon.Test/bin/Debug/Pantheon.Test.dll'
  end
end

desc 'Run all tests'
task :test => [:'test:syntax', :'test:system']

desc 'Generate a status report based on project data from Pivotal Tracker'
task :status_report, :iteration do |t, args|
  iteration = args[:iteration].to_i
  raise 'No iteration specified.' unless iteration

  start_date = '9/6/2010'.to_date
  end_date = '9/13/2010'.to_date

  iteration_start_date = start_date + iteration.weeks
  iteration_end_date = end_date + iteration.weeks

  all_stories = []
  expected_stories = []
  next_stories = []
  new_stories = []

  overview = Haml::Engine.new(File.read("StatusOverviews/#{iteration}.html.haml")).render

  FasterCSV.open "Pivotal/#{iteration}.csv", :headers => :first_row do |csv|
    csv.each do |row|
      story = OpenStruct.new :iteration => row['Iteration'].to_i,
        :title => row['Story'],
        :status => row['Current State'],
        :points => row['Estimate'].to_i,
        :created_at => row['Created at'].to_date

      all_stories << story

      if story.iteration == iteration
        expected_stories << story
      elsif story.iteration == iteration + 1
        next_stories << story
      end

      if story.created_at >= iteration_start_date and story.created_at <= iteration_end_date
        new_stories << story
      end
    end
  end

  velocity = 1.0 / 2.0 * (all_stories.select do |story| # change 1.0 / 1.0 to 1.0 / 2.0 for Iteration 2, 1.0 / 3.0 for Iteration 3, then leave it alone...
    story.status == 'accepted' and story.iteration > iteration - 3 and story.iteration <= iteration
  end.inject 0 do |memo, story|
    memo + story.points
  end)

  iteration_points_complete = expected_stories.select do |story|
    story.status == 'accepted'
  end.inject 0 do |memo, story|
    memo + story.points
  end

  iteration_points_defined = new_stories.inject 0 do |memo, story|
    memo + story.points
  end

  total_points_complete = all_stories.select do |story|
    story.status == 'accepted'
  end.inject 0 do |memo, story|
    memo + story.points
  end

  total_points_defined = all_stories.inject 0 do |memo, story|
    memo + story.points
  end

  template = File.read 'StatusReport.html.haml'
  engine = Haml::Engine.new template
  output = engine.render Object.new,
    :velocity => velocity,
    :iteration_points_complete => iteration_points_complete,
    :iteration_points_defined => iteration_points_defined,
    :total_points_complete => total_points_complete,
    :total_points_defined => total_points_defined,
    :iteration => iteration,
    :start_date => start_date,
    :end_date => end_date,
    :expected_stories => expected_stories,
    :next_stories => next_stories,
    :new_stories => new_stories,
    :overview => overview

  File.open "Iterations/#{iteration}.html", 'w' do |file|
    file.write output
  end
end

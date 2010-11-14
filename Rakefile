require 'rubygems'
require 'faster_csv'
require 'haml'
require 'ostruct'
require 'active_support/all'

module Mono
  Root = "/Library/Frameworks/Mono.framework"
  Lib = "#{Root}/Libraries"
  Gac = "#{Lib}/mono/gac"

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
  Lib = "#{Mono::Lib}/boo"
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
  Assemblies = %W|Mono.TextEditor
  MonoDevelop.Core
  MonoDevelop.Ide
  MonoDevelop.DesignerSupport
  MonoDevelop.Deployment
  Mono.Cecil
  libstetic
  libsteticui
  MonoDevelop.GtkCore|

  module Core
    Build = "#{MonoDevelop::Root}/main/build/bin"
    Assemblies = %W|Mono.TextEditor|
  end

  module AddIns
    Build = "#{MonoDevelop::Root}/main/build/AddIns"
    Lib = "#{MonoDevelop::Application}/lib/monodevelop/AddIns"
    Assemblies = %W|MonoDevelop.Gettext
    MonoDevelop.GtkCore|

    def self.assembly_files
      Assemblies.map do |assembly|
        "#{MonoDevelop::AddIns::Build}/#{assembly}/#{assembly}.dll"
      end
    end
  end

  module BooBinding
    Root = "#{MonoDevelop::Root}/extras/BooBinding"
    Build = "#{Root}/build"
    Binary = "#{Build}/BooBinding.dll"
  end

  def self.build(solution, options)
    configuration = options[:configuration]
    project = options[:project]
    system "#{Application}/mdtool build #{"-c:#{configuration}" if configuration} #{"-p:#{project}" if project} #{solution}"
  end
end

module NUnit
  Root = "Dependencies/NUnit"
  Framework = "#{Root}/framework"
  Assemblies = %W|nunit.framework|
end

task :default => [:test]

MonoDevelop::AddIns::assembly_files.each do |assembly_file|
  file assembly_file do
    Rake::Task[:'build:monodevelop'].invoke
  end
end

file MonoDevelop::BooBinding::Binary do
  Rake::Task[:'build:monodevelop:boo_binding'].invoke
end

desc 'Start a Boo console with Pantheon references'
task :console do
  system 'booish Pantheon/bin/Debug/Pantheon.dll Pantheon.Boo/bin/Debug/Pantheon.Boo.dll Pantheon.Boo.Test/bin/Debug/Pantheon.Boo.Test.dll Pantheon.Syntax/bin/Debug/Pantheon.Syntax.dll Pantheon.Syntax.Test/bin/Debug/Pantheon.Syntax.Test.dll Pantheon.Test/bin/Debug/Pantheon.Test.dll'
end

desc 'Build Pantheon'
task :build do
  MonoDevelop::build 'Pantheon.sln', :configuration => 'release'
end

namespace :clean do
  namespace :monodevelop do
    desc 'Clean Boo binding'
    task :boo_binding do
      cd MonoDevelop::BooBinding::Root do
        system 'make clean'
      end
    end
  end
end

namespace :build do
  desc 'Build MonoDevelop'
  task :monodevelop do
    cd MonoDevelop::Root do
      cp '../monodevelop_profile', "profiles/pantheon"
      system './configure --profile=pantheon'
      system 'make'
    end
  end

  namespace :monodevelop do
    desc 'Build Boo binding'
    task :boo_binding do
      cd MonoDevelop::BooBinding::Root do
        system './configure'
        system 'make'
      end
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
  task :monodevelop do
    system "open -W Dependencies/MonoDevelop-2.4-r159698.dmg"
    system "sudo cp -r '/Volumes/MonoDevelop/MonoDevelop.app' '/Applications/MonoDevelop.app'"
  end

  desc 'Install NUnit'
  task :nunit do
    NUnit::Assemblies.each do |assembly|
      Mono::install_assembly "#{NUnit::Framework}/#{assembly}.dll"
    end
  end

  desc 'Install Rhino.Mocks'
  task :rhino_mocks do
    Mono::install_assembly 'Dependencies/Rhino.Mocks/Rhino.Mocks.dll'
  end

  namespace :monodevelop do
    desc 'Install MonoDevelop core assemblies'
    task :core => [:'build:monodevelop'] do
      MonoDevelop::Core::Assemblies.each do |core_assembly|
        Mono::install_assembly "#{MonoDevelop::Core::Build}/#{core_assembly}.dll"
      end
    end

    desc 'Install addins'
    task :addins => MonoDevelop::AddIns::assembly_files do
      MonoDevelop::AddIns::Assemblies.each do |addin|
        system "sudo mkdir -p '#{MonoDevelop::AddIns::Lib}/#{addin}/'"
        system "sudo cp -r #{MonoDevelop::AddIns::Build}/#{addin}/* '#{MonoDevelop::AddIns::Lib}/#{addin}/'"
      end
    end

    desc 'Install Boo binding'
    task :boo_binding => [MonoDevelop::BooBinding::Binary, :'install:monodevelop:addins'] do
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
        Dir.glob "#{Mono::Gac}/#{assembly_name}/*/#{assembly_name}.dll" do |gac_file|
          system "sudo ln -fs '#{gac_file}' '#{Mono::Lib}/mono/boo/#{assembly_name}.dll'"
        end
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
  desc 'Run syntax tests'
  task :syntax do
    sh "mono #{NUnit::Root}/nunit-console.exe Pantheon.Test.Syntax/bin/Debug/Pantheon.Test.Syntax.dll"
  end

  desc 'Run unit tests'
  task :units do
    sh "mono #{NUnit::Root}/nunit-console.exe Pantheon.Test.Units/bin/Debug/Pantheon.Test.Units.dll"
  end

  desc 'Run functional tests'
  task :functional do
    sh "mono #{NUnit::Root}/nunit-console.exe Pantheon.Test.Functional/bin/Debug/Pantheon.Test.Functional.dll"
  end
end

desc 'Run all tests'
task :test => [:'test:syntax', :'test:units', :'test:functional']

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

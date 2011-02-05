def mono(cmd)
  system "mono --debug --runtime=v4.0.30319 #{cmd}"
end

task :default => [:nunit]

task :nunit do
  mono 'NUnit/nunit-console.exe Pantheon.Test/bin/Debug/Pantheon.Test.dll'
end

task :'nunit:gui' do
  mono 'NUnit/nunit.exe Pantheon.Test/bin/Debug/Pantheon.Test.dll'
end

task :console do
  mono 'Pantheon.Interactive/bin/Debug/Pantheon.Interactive.exe'
end

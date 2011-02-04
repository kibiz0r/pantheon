task :default => [:nunit]

task :nunit do
  system 'mono --debug --runtime=v4.0.30319 ~/NUnit/bin/net-2.0/nunit-console.exe Pantheon.Test/bin/Debug/Pantheon.Test.dll'
end

task :console do
  system 'mono --debug --runtime=v4.0.30319 Pantheon.Interactive/bin/Debug/Pantheon.Interactive.exe'
end

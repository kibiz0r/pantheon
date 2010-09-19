using System;
using System.Reflection;

namespace Pantheon
{
    public static class Application
    {
        public static void Run()
        {
            try
            {
                Console.WriteLine("Starting Pantheon");
                Console.WriteLine("Entry assembly is {0}", Assembly.GetEntryAssembly());
                var startScreenType = Assembly.GetEntryAssembly().GetType("screen_Start");
                var startScreen = Activator.CreateInstance(startScreenType) as Screen;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Died from exception {0}", exception);
            }
            finally
            {
                Console.WriteLine("Ending Pantheon");
            }
        }
    }
}


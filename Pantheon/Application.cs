using System;
using System.Reflection;
using AllegroSharp;

namespace Pantheon
{
    public static class Application
    {
        public static Font Font
        {
            get;
            set;
        }
        public static Display Display
        {
            get;
            set;
        }

        public static void AllegroMain()
        {
            try
            {
                Console.WriteLine("Starting Allegro");
                if (!Allegro.InstallSystem())
                {
                    Console.WriteLine("Allegro.InstallSystem failed");
                }
                Font = Ttf.LoadFont("Arial.ttf", 12, TtfFlags.None);
                if (Font == null)
                {
                    Console.WriteLine("Ttf.LoadFont(\"Arial.ttf\", 12, TtfFlags.None) failed");
                }
                Display = Display.Create(800, 600);
                if (Display == null)
                {
                    Console.WriteLine("Display.Create(800, 600) failed");
                }
                EventQueue eventQueue = EventQueue.Create();
                eventQueue.RegisterEventSource(Display.EventSource);
                Console.WriteLine("Entry assembly is {0}", Assembly.GetEntryAssembly());
                var startScreenType = Assembly.GetEntryAssembly().GetType("screen_Start");
                var startScreen = Activator.CreateInstance(startScreenType) as Screen;
                while (true)
                {
                    startScreen.Render();
                    Display.Flip();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Allegro died from exception {0}", exception);
            }
        }

        public static void Run()
        {
            try
            {
                Console.WriteLine("Starting Pantheon");
                Console.WriteLine("Passing off to Allegro");
                Allegro.RunMain(AllegroMain);
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


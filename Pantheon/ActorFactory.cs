using System;
namespace Pantheon
{
    public static class ActorFactory
    {
        public static T CreateActor<T>() where T : Actor, new()
        {
            Console.WriteLine("Creating actor");
            var actor = new T();
            Application.World.Actors.Add(actor);
            foreach (var view in Application.Views)
            {
                view.Sprites.Add(new Sprite(actor));
            }
            return actor;
        }
    }
}


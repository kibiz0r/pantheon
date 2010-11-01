using System;
namespace Pantheon
{
    public static class WorldFactory
    {
        public static T CreateWorld<T>() where T : IWorld, new()
        {
            var world = new T();
            Application.World = world;
            Universe.Current.Send(new Message(new MessageComponent("World"), new MessageComponent("Starts")));
            return world;
        }
    }
}


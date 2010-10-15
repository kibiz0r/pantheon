using System;
namespace Pantheon
{
    public static class WorldFactory
    {
        public static T CreateWorld<T>() where T : IWorld, new()
        {
            var world = new T();
            Application.World = world;
            MessageManager.Send(new Message("World.Starts"));
            return world;
        }
    }
}


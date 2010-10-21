using System;
namespace Pantheon
{
    public static class PlayerFactory
    {
        public static T CreatePlayer<T>() where T : IPlayer, new()
        {
            var player = new T();
            return player;
        }
    }
}


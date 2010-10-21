using System;

namespace Pantheon
{
    public class Player : IPlayer
    {
        private static int nextId = 1;

        public int Id { get; set; }

        public Player()
        {
            Id = nextId;
            nextId++;
        }
    }
}
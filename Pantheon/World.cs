using System;
using System.Collections.Generic;
namespace Pantheon
{
    public class World : MessageHandler, IWorld
    {
        public World()
        {
            Actors = new List<Actor>();
            Players = new List<IPlayer>();
        }

        public virtual void Starts()
        {
        }

        public override void HandleMessage(Message message)
        {
            if (message.Name == "World.Starts")
            {
                this.Starts();
            }
        }

        public ICollection<Actor> Actors
        {
            get;
            set;
        }

        public ICollection<IPlayer> Players
        {
            get;
            set;
        }
    }
}
using System;
using System.Collections.Generic;
namespace Pantheon
{
    public class World : IWorld
    {
        public World()
        {
            Actors = new List<Actor>();
        }

        public virtual void Starts()
        {
        }

        public virtual void HandleMessage(Message message)
        {
            if (message.String == "World.Starts")
            {
                this.Starts();
            }
        }

        public ICollection<Actor> Actors
        {
            get;
            set;
        }
    }
}
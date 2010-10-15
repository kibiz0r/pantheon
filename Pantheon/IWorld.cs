using System;
using System.Collections.Generic;

namespace Pantheon
{
    public interface IWorld
    {
        ICollection<Actor> Actors
        {
            get;
            set;
        }
        void Starts();
    }
}


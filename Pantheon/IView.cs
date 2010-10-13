using System;
using System.Collections.Generic;

namespace Pantheon
{
    public interface IView
    {
        ICollection<ISprite> Sprites { get; set; }
    }
}


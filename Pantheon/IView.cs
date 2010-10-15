using System;
using System.Collections.Generic;

namespace Pantheon
{
    public interface IView : IMessageHandler
    {
        ICollection<ISprite> Sprites { get; set; }
    }
}


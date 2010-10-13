using System;
using System.Collections.Generic;

namespace Pantheon
{
    public class View<WorldType> : IView where WorldType : World
    {
        public View()
        {
            Sprites = new List<ISprite>();
        }

        public ICollection<ISprite> Sprites { get; set; }
    }
}
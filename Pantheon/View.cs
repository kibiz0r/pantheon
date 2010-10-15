using System;
using System.Collections.Generic;

namespace Pantheon
{
    public class View : IView
    {
        public View()
        {
            Sprites = new List<ISprite>();
        }

        public ICollection<ISprite> Sprites
        {
            get;
            set;
        }

        public void HandleMessage(Message message)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;

namespace Pantheon
{
    public class View : MessageHandler, IView
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

        public override void HandleMessage(Message message)
        {
            
        }
    }
}
using System;
namespace Pantheon
{
    public class ScreenElement
    {
        public ScreenElement()
        {
        }

        public virtual void Render()
        {
        }

        public float Top
        {
            get;
            set;
        }

        public float Left
        {
            get;
            set;
        }
    }
}


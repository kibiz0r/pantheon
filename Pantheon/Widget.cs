using System;
namespace Pantheon
{
    public abstract class Widget
    {
        public Widget()
        {
        }

        public abstract void Render();

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


using System;
namespace Pantheon
{
    public abstract class Widget : IWidget
    {
        public Widget()
        {
        }

        public abstract void Render();

        public IView View { get; set; }

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


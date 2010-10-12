using System;
namespace Pantheon
{
    public abstract class Widget : IWidget //<ViewType> : IWidget where ViewType : IView
    {
        public Widget()
        {
        }

        public abstract void Render();

        //public ViewType View { get; set; }

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


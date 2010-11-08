using System;
namespace Pantheon
{
    public interface IWidget
    {
        void Render();
        IView View
        {
            get;
            set;
        }
    }
}


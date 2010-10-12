using System;
namespace Pantheon
{
    public class View<WorldType> : IView where WorldType : World
    {
        public View()
        {
        }

        public override string ToString()
        {
            return "hurr durp im a view";
        }
    }
}


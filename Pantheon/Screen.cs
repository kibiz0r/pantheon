using System;
using System.Collections.Generic;

namespace Pantheon
{
    public class Screen
    {
        public List<ScreenElement> Elements { get; set; }

        public Screen()
        {
            Elements = new List<ScreenElement>();
        }

        public void Render()
        {
            foreach (var element in Elements)
            {
                element.Render();
            }
        }
    }
}


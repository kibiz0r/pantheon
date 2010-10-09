using System;
using System.Collections.Generic;

namespace Pantheon
{
    public class Screen
    {
        public List<Widget> Widgets { get; set; }

        public Screen()
        {
            Widgets = new List<Widget>();
        }

        public void Render()
        {
            foreach (var widget in Widgets)
            {
                widget.Render();
            }
        }
    }
}


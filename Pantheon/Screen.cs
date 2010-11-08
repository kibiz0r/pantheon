using System;
using System.Collections.Generic;

namespace Pantheon
{
    public class Screen
    {
        public List<IWidget> Widgets { get; set; }

        public Screen()
        {
            Widgets = new List<IWidget>();
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


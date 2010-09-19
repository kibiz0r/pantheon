using System;
using AllegroSharp;

namespace Pantheon
{
    public class Label : ScreenElement
    {
        public string Text
        {
            get;
            set;
        }

        public Label(string text)
        {
            Text = text;
        }

        public override void Render()
        {
            Application.Font.Draw(Display.Width / 2, Display.Height / 2, FontDrawFlags.AlignCentre, Text);
        }
    }
}


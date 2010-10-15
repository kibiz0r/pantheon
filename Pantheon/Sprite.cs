using System;
using AllegroSharp;

namespace Pantheon
{
    public class Sprite : ISprite
    {
        public Bitmap Bitmap
        {
            get;
            set;
        }
        public Actor Actor { get; set; }

        public Sprite(Actor actor)
        {
            Actor = actor;
            Bitmap = Image.LoadBitmap(String.Format("Sprites/{0}", actor.GetType()));
        }

        public void Render()
        {
            Console.WriteLine("Rendering sprite!");
            Bitmap.Draw(Actor.X, Actor.Y, DrawFlags.None);
        }
    }
}


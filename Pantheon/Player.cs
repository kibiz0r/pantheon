using System;
namespace Pantheon
{
    public class Player
    {
        private static Player me = new Player();

        public static Player Me
        {
            get { return me; }
        }
    }
}


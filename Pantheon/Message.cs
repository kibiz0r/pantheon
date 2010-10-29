using System;

namespace Pantheon
{
    public class Message
    {
        public string Name
        {
            get;
            set;
        }
        public object[] Args
        {
            get;
            set;
        }

        public Message()
        {
            //
        }

        public Message(string name)
        {
            Name = name;
        }

        public Message(string name, params object[] args)
        {
            Name = name;
            Args = args;
        }
    }
}


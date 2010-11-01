using System;
namespace Pantheon
{
    public sealed class MessageComponent
    {
        public string Name
        {
            get;
            private set;
        }
        public object[] Args
        {
            get;
            private set;
        }

        public MessageComponent(string name, params object[] args)
        {
            Name = name;
            Args = args;
        }
    }
}


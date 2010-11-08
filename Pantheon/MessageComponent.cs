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
        public MessageArgument[] Arguments
        {
            get;
            private set;
        }

        public MessageComponent(string name, params MessageArgument[] arguments)
        {
            Name = name;
            Arguments = arguments;
        }
    }
}


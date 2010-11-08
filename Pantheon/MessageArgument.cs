using System;
namespace Pantheon
{
    public class MessageArgument
    {
        public MessageArgument(string name, object @value)
        {
            Name = name;
            Value = @value;
        }

        public string Name
        {
            get;
            private set;
        }
        public object Value
        {
            get;
            private set;
        }
    }
}


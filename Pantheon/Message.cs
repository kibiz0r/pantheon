using System;

namespace Pantheon
{
    public class Message
    {
        public string String { get; set; }

        public Message(string @string)
        {
            String = @string;
        }
    }
}


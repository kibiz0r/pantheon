using System;
using System.Collections.Generic;
using System.Linq;

namespace Pantheon
{
    public class Message
    {
        public List<MessageComponent> Components = new List<MessageComponent>();

        public string Name
        {
            get
            {
                return String.Join(".", Components.Select(c => c.Name).ToArray());
            }
        }

        public Message(params MessageComponent[] components)
        {
            Components.AddRange(components);
        }
    }
}


using System;
using System.Collections.Generic;
namespace Pantheon
{
    public class MessageDefinition
    {
        public MessageDefinition(params MessageDefinitionComponent[] components)
        {
            Components.AddRange(components);
        }

        public List<MessageDefinitionComponent> Components = new List<MessageDefinitionComponent>();
    }
}


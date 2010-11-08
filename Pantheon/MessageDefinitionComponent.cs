using System;
namespace Pantheon
{
    public class MessageDefinitionComponent
    {
        public MessageDefinitionComponent(params string[] parameters)
        {
            Parameters = parameters;
        }

        public string[] Parameters { get; private set; }
    }
}


using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pantheon
{
    public class Domain
    {
        public IList<Message> Outbox
        {
            get;
            set;
        }

        public Dictionary<string, Action> MessageMethods = new Dictionary<string, Action>();

        public Domain()
        {
            Outbox = new List<Message>();
        }

        public void Receive(Message message)
        {
            var component = message.Components[0];
            Action method;
            if (MessageMethods.TryGetValue(component.Name, out method))
            {
                method();
            }
        }
    }
}


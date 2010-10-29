using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pantheon
{
    public class Domain
    {
        public IList<Message> Outbox { get; set; }

        public Domain()
        {
            Outbox = new List<Message>();
        }

        public void Receive(Message message)
        {
            var name = String.Format("{0}Message", message.Name);
            this.GetType().InvokeMember(name, BindingFlags.InvokeMethod, Type.DefaultBinder, this, message.Args);
        }

        public void Send(string messageName)
        {
            Outbox.Add(new Message(messageName));
        }
    }
}


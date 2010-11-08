using System;
using System.Collections.Generic;
using System.Linq;

namespace Pantheon
{
    public class Universe : IDisposable
    {
        public Universe()
        {
            current = this;
        }

        public static Universe Current
        {
            get
            {
                return current;
            }
        }

        protected static Universe current = null;

        public List<Domain> Domains = new List<Domain>();
        public List<Message> Messages = new List<Message>();

        public void Dispose()
        {
            current = null;
        }

        public void Tick()
        {
            var previousMessages = new List<Message>(Messages);
            Messages.Clear();
            foreach (var message in previousMessages)
            {
                foreach (var domain in Domains)
                {
                    domain.Receive(message);
                }
            }
        }

        public void Send(Message message)
        {
            Messages.Add(message);
        }

        public Message Receive()
        {
            return Messages.FirstOrDefault();
        }
    }
}


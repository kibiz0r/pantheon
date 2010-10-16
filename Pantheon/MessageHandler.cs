using System;
using System.Collections.Generic;

namespace Pantheon
{
    public abstract class MessageHandler : IMessageHandler
    {
        public MessageHandler()
        {
            Controllers = new List<Controller>();
        }

        public abstract void HandleMessage(Message message);

        public ICollection<Controller> Controllers { get; set; }
    }
}


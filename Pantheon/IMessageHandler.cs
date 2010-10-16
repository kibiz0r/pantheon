using System;
using System.Collections.Generic;

namespace Pantheon
{
    public interface IMessageHandler
    {
        void HandleMessage(Message message);
        ICollection<Controller> Controllers
        {
            get;
            set;
        }
    }
}


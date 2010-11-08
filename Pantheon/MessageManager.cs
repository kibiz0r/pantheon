using System;
using System.Collections.Generic;

namespace Pantheon
{
    public static class MessageManager
    {
        public static Queue<Message> Messages = new Queue<Message>();

        public static void Send(Message message)
        {
            Messages.Enqueue(message);
        }

        public static void Update()
        {
            while (Messages.Count > 0)
            {
                var message = Messages.Dequeue();
                Application.World.HandleMessage(message);
                foreach (var view in Application.Views)
                {
                    view.HandleMessage(message);
                }
            }
        }
    }
}


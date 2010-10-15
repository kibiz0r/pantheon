using System;
namespace Pantheon
{
    public interface IMessageHandler
    {
        void HandleMessage(Message message);
    }
}


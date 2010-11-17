using System;
using System.Collections.Generic;
using System.Linq;

namespace Pantheon
{
    public class MessageDispatcher
    {
        public MessageDispatcher()
        {
        }

        private class MessageHandler
        {
            public Dictionary<string, MessageHandler> Subhandlers = new Dictionary<string, MessageHandler>();
            public List<Action<Message>> Callbacks = new List<Action<Message>>();
        }

        private Dictionary<string, MessageHandler> handlers = new Dictionary<string, MessageHandler>();

        public void Register(IEnumerable<string> prototype, Action<Message> callback)
        {
            var handlerDictionary = handlers;
            MessageHandler handler = null;
            foreach (var prototypePart in prototype)
            {
                handler = null;
                if (handlerDictionary.TryGetValue(prototypePart, out handler))
                {

                }
                else
                {
                    handler = new MessageHandler();
                    handlerDictionary.Add(prototypePart, handler);
                }
                handlerDictionary = handler.Subhandlers;
            }
            handler.Callbacks.Add(callback);
        }

        public void Dispatch(Message message)
        {
            var handlerDictionary = handlers;
            MessageHandler handler = null;
            var submessage = message;
            while (true)
            {
                handler = null;
                if (handlerDictionary.TryGetValue(submessage.MessageName, out handler))
                {
                    handlerDictionary = handler.Subhandlers;
                    submessage = submessage.ChildMessage;
                }
                else
                {
                    break;
                }
                if (submessage == null)
                {
                    break;
                }
            }
            if (handler != null)
            {
                foreach (var callback in handler.Callbacks)
                {
                    callback(message);
                }
            }
        }
    }
}


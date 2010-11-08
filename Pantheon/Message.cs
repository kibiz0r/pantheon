using System;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang;

namespace Pantheon
{
    public class Message : IQuackFu
    {
        public object QuackGet(string name, object[] parameters)
        {
            foreach (var component in Components)
            {
                var arg = component.Arguments.FirstOrDefault(a => a.Name == name);
                if (arg != null)
                {
                    return arg.Value;
                }
            }
            return null;
        }

        public object QuackSet(string name, object[] parameters, object value)
        {
            throw new NotImplementedException();
        }

        public object QuackInvoke(string name, params object[] args)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<MessageComponent> Components = new System.Collections.Generic.List<MessageComponent>();

        public string Name
        {
            get
            {
                return String.Join(".", Components.Select(c => c.Name).ToArray());
            }
        }

        public Message(params MessageComponent[] components)
        {
            Components.AddRange(components);
        }
    }
}


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

        public readonly string MessageName = null;
        public readonly Message ChildMessage = null;

        public Message(string name) : this(name, null)
        {}

        public Message(string name, Message child)
        {
            this.MessageName = name;
            this.ChildMessage = child;
        }
    }
}


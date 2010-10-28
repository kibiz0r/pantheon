using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pantheon
{
    public class Domain
    {
        public void Receive(Message message)
        {
            var name = String.Format("{0}Message", message.Name);
            this.GetType().InvokeMember(name, BindingFlags.InvokeMethod, Type.DefaultBinder, this, new object[] { message });
        }
    }
}


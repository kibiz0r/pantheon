using System;
using System.Collections.Generic;

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

        public void Dispose()
        {
            current = null;
        }

        public void Send()
        {
            //
        }

        public Message Receive()
        {
            return null;
        }
    }
}


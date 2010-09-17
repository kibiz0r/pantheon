using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    public static class Definitely
    {
        public static IResolveConstraint HasMessage(string message)
        {
            return HasMessages(message);
        }

        public static IResolveConstraint HasMessages(params string[] messages)
        {
            return new HasMessagesConstraint(messages);
        }
    }
}


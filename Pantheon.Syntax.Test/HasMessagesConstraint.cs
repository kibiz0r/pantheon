using System;
using System.Linq;
using NUnit.Framework.Constraints;
using NUnit.Framework;

namespace Pantheon.Syntax.Test
{
    public class HasMessagesConstraint : Constraint
    {
        private string[] messages;

        public HasMessagesConstraint(params string[] messages)
        {
            this.messages = messages;
        }

        public override bool Matches(object actual)
        {
            Type type = (Type)actual;
            this.actual = actual;
            foreach (var message in messages)
            {
                var method = type.GetMethod(String.Format("message_{0}", message));
                if (method == null)
                {
                    return false;
                }
                if ((method.GetCustomAttributes(typeof(Pantheon.MessageAttribute), true)[0] as Pantheon.MessageAttribute).Name != message)
                {
                    return false;
                }
            }
            return true;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WritePredicate("has messages");
            writer.WriteExpectedValue(String.Join(", ", messages));
        }

        public override void WriteActualValueTo(MessageWriter writer)
        {
            Type type = (Type)actual;
            var names = (from method in type.GetMethods()
                where method.GetCustomAttributes(typeof(Pantheon.MessageAttribute), true).Any()
                select method.Name).ToArray();
            writer.WriteActualValue(String.Join(", ", names));
        }
    }
}


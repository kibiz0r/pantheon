using System;
using NUnit.Framework.Constraints;
using System.Reflection;
using System.Linq;
using NUnit.Framework;


namespace Pantheon.Test
{
    public class IsATestConstraint : Constraint
    {
        public override bool Matches(object actual)
        {
            this.actual = actual;
            MethodInfo method = actual as MethodInfo;
            if (actual == null)
            {
                return false;
            }
            if (!method.GetCustomAttributes(typeof(TestAttribute), true).Any())
            {
                return false;
            }
            return true;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WritePredicate("is a test");
        }
    }
}


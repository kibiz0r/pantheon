using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Milliseconds
    {
        [Test]
        public void Parses14_53ms()
        {
            Assert.That("14.53ms", Parses.To(Expression.Constant(TimeSpan.FromMilliseconds(14.53))));
        }
    }
}


using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Seconds
    {
        [Test]
        public void Parses7_8s()
        {
            Assert.That("7.8s", Parses.To(Expression.Constant(TimeSpan.FromSeconds(7.8))));
        }
    }
}


using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Minutes
    {
        [Test]
        public void Parses23_2m()
        {
            Assert.That("23.2m", Parses.To(Expression.Constant(TimeSpan.FromMinutes(23.2))));
        }
    }
}


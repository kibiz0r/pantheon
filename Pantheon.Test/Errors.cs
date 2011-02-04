using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Errors
    {
        [Test]
        public void DoesntParseUnknownLiterals()
        {
            Assert.That("8o", Parses.Throwing<Exception>());
        }
    }
}


using System;
using NUnit.Framework;

namespace Pantheon.Test
{
    [TestFixture]
    public class StringExtensionsTest
    {
        public StringExtensionsTest()
        {
        }

        [TestCase("graphic", "Graphic")]
        [TestCase("radio_button", "RadioButton")]
        [TestCase("a", "A")]
        [TestCase("", "")]
        [TestCase("_", "_")]
        public void PascalCase(string str, string expected)
        {
            Assert.That(str.PascalCase(), Is.EqualTo(expected));
        }
    }
}


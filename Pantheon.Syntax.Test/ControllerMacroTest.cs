using System;
using NUnit.Framework;
using Pantheon.Syntax.Test.Boo;

namespace Pantheon.Syntax.Test
{
    [TestFixture]
    public class ControllerMacroTest
    {
        [Test]
        public void ShouldExist()
        {
            Assert.That(typeof(ShouldExistController), Is.Not.Null);
        }

        [Test]
        public void ShouldBeAController()
        {
            Assert.That(typeof(ShouldExistController).BaseType, Is.EqualTo(typeof(Pantheon.Controller)));
        }

        [Test]
        public void ShouldHaveAMessage()
        {
            var method = typeof(ShouldHaveAMessageController).GetMethod("BlahMessage");
            Assert.That(method, Is.Not.Null);
            Assert.That((method.GetCustomAttributes(typeof(Pantheon.MessageAttribute), true)[0] as Pantheon.MessageAttribute).Name,
                Is.EqualTo("Blah"));
        }
    }
}
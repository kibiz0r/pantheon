using System;
using NUnit.Framework;
using Pantheon.Syntax.Test.Definitions;

namespace Pantheon.Syntax.Test
{
    [TestFixture]
    public class ControllerMacroTest
    {
        [Test]
        public void ShouldExist()
        {
            Assert.That(typeof(controller_ShouldExist), Is.Not.Null);
        }

        [Test]
        public void ShouldBeAController()
        {
            Assert.That(typeof(controller_ShouldExist).BaseType, Is.EqualTo(typeof(Pantheon.Controller)));
        }

        [Test]
        public void ShouldHaveAMessage()
        {
            Assert.That(typeof(controller_ShouldHaveAMessage), Definitely.HasMessages("AMessage"));
        }

        [Test]
        public void ShouldHaveTwoMessages()
        {
            Assert.That(typeof(controller_ShouldHaveTwoMessages), Definitely.HasMessages("MessageOne", "MessageTwo"));
        }
    }
}
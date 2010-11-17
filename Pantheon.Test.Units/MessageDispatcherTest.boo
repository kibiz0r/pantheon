import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageDispatcherTest:
    [Test]
    def SimpleMessageDispatch():
        dispatcher = MessageDispatcher()
        flag = false
        dispatcher.Register(("Foo",)) def(message as Message):
            Assert.That(message.MessageName, Is.EqualTo("Foo"))
            flag = true
        dispatcher.Dispatch(Message("Foo"))
        Assert.That(flag)

    [Test]
    def TwoPartMessageDispatch():
        dispatcher = MessageDispatcher()
        flag = false
        dispatcher.Register(("Foo", "Bar")) def(message as Message):
            Assert.That(message.MessageName, Is.EqualTo("Foo"))
            flag = true
        dispatcher.Dispatch(Message("Foo", Message("Bar")))
        Assert.That(flag)
import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class DomainTest:
    domain MyDomain:
        message Foo:
            send FooReceived()

        /*message WithArgs(i as int, s as string):
            #send WithArgsReceived(i, s)

        message Multi.Part.Message(i as int):
            send Multi.Part.MessageReceived(i)

        message Split(a as int).Params(b as int, c as string):
            pass
            //SplitParamsReceived(a, b, c)*/

    universe as Universe

    [SetUp]
    def SetUp():
        universe = Universe()

    [TearDown]
    def TearDown():
        universe.Dispose()

    [Test]
    def CanSendAndReceiveMessages():
        domain MyDomain()
        send Foo
        tick
        receive msg = FooReceived
        Assert.That(msg, Is.Not.Null)

    [Test]
    [Ignore]
    def CanSendAndReceiveMessagesWithArgs():
        domain MyDomain()
        send WithArgs(5, "hi")
        receive msg = WithArgsReceived(i as int, s as string)
        Assert.That(msg.i, Is.EqualTo(5))
        Assert.That(msg.s, Is.EqualTo("hi"))

    [Test]
    [Ignore]
    def CanSendAndReceiveMultiPartMessages():
        domain MyDomain()
        send Multi.Part.Message(3)
        receive msg = Multi.Part.Message.Received(i as int)
        Assert.That(msg.i, Is.EqualTo(3))

    [Test]
    [Ignore]
    def CanDefineSplitParams():
        pass
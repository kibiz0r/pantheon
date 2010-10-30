import NUnit.Framework
import Pantheon
import Rhino.Mocks

[TestFixture]
class DomainTest:
    domain MyDomain:
        message Foo:
            FooReceived()

        message DoStuff:
            send DoingStuff

        message WithArgs(i as int, s as string):
            WithArgsReceived(i, s)

        message Multi.Part.Message(i as int):
            MultiPartMessageReceived(i)

        virtual def FooReceived():
            pass

        virtual def WithArgsReceived(i as int, s as string):
            pass

        virtual def MultiPartMessageReceived(i as int):
            pass

    mocks as MockRepository
    dom as MyDomainDomain

    [SetUp]
    def SetUp():
        mocks = MockRepository()
        dom = mocks.StrictMock[of MyDomainDomain]()

    [TearDown]
    def TearDown():
        mocks.VerifyAll()

    [Test]
    def CanReceiveMessages():
        foo as Expect.Action = { dom.FooReceived() }
        Expect.Call(foo)
        mocks.ReplayAll()

        msg = Message("Foo")
        dom.Receive(msg)

    [Test]
    def CanSendMessages():
        mocks.ReplayAll()

        msg = Message("DoStuff")
        dom.Receive(msg)
        Assert.That(dom.Outbox, Has.Some.With.Property("Name").EqualTo("DoingStuff"))

    [Test]
    def CanReceiveMessagesWithArgs():
        withArgs as Expect.Action = { dom.WithArgsReceived(1, "hi") }
        Expect.Call(withArgs)
        mocks.ReplayAll()

        msg = Message("WithArgs", 1, "hi")
        dom.Receive(msg)

    [Test]
    def CanDefineMultiPartMessages():
        multiPart as Expect.Action = { dom.MultiPartMessageReceived(3) }
        Expect.Call(multiPart)
        mocks.ReplayAll()

        msg = Message("Multi.Part.Message", 3)
        dom.Receive(msg)
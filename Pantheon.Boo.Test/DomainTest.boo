import NUnit.Framework
import Pantheon

[TestFixture]
class DomainTest:
    domain MyDomain:
        def constructor():
            pass

        public property Flag as bool = false

        static def foo():
            pass

        message Foo:
            Flag = true

    [Test]
    def CanReceiveMessages():
        dom = MyDomainDomain()
        msg = Message("Foo")
        dom.Receive(msg)
        Assert.That(dom.Flag, Is.True)
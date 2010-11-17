import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageDefinitionTest:
    [Test]
    [Ignore]
    def SimpleMessageDefinition():
        expected = [|
            public class FooMessage(Pantheon.Message):
                public def constructor():
                    super("Foo")

            public class FooMessage[of ChildMessageType(Pantheon.Message)](FooMessage):
                public def constructor():
                    super()

                public property ChildMessage as ChildMessageType
        |]
        actual = MessageDefinitionExpression([| Foo |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def TwoPartMessageExpression():
        expected = [|
            public class FooMessage(Pantheon.Message):
                public def constructor():
                    super("Foo")

            public class FooMessage[of ChildMessageType(Pantheon.Message)](FooMessage):
                public def constructor():
                    super()

                public property ChildMessage as ChildMessageType

            public class BarMessage(Pantheon.Message):
                public def constructor():
                    super("Bar")

            public class BarMessage[of ChildMessageType(Pantheon.Message)](BarMessage):
                public def constructor():
                    super()

                public property ChildMessage as ChildMessageType
        |]
        actual = MessageDefinitionExpression([| Foo.Bar |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def MessageWithArgs():
        expected = [|
            public class FooMessage(Pantheon.Message):
                public def constructor(i as int, s as string):
                    super("Foo")
                    self.i = i
                    self.s = s

                public property i as int
                public property s as string

            public class FooMessage[of ChildMessageType(Pantheon.Message)](FooMessage):
                public def constructor(i as int, s as string):
                    super(i, s)

                public property ChildMessage as ChildMessageType
        |]
        actual = MessageDefinitionExpression([| Foo(i as int, s as string) |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def TwoPartMessageWithArgs():
        expected = [|
            namespace Messages.First.Second
            public class FirstComponent(Pantheon.MessageComponent):
                public def constructor(a as int):
                    super("First")
                    self.a = a

                public property a as int
            public class SecondComponent(Pantheon.MessageComponent):
                public def constructor(b as int):
                    super("Second")
                    self.b = b

                public property b as int
            public class FirstSecondMessage(Pantheon.Message):
                public def constructor(a as int, b as int):
                    super(First = FirstComponent(a), Second = SecondComponent(b))

                public property First as FirstComponent
                public property Second as SecondComponent

                public a as int:
                    get:
                        return First.a

                public b as int:
                    get:
                        return Second.b
        |]
        actual = MessageDefinitionExpression([| First(a as int).Second(b as int) |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))
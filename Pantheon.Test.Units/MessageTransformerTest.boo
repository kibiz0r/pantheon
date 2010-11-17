import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageTransformerTest:
    [Test]
    def SimpleMessage():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    FooMessage()
        |]
        actual = MessageTransformer([| Foo |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def SimpleMessageAsCall():
        expected = [|
            def AnotherMessageTransformer(message as Pantheon.Message):
                try:
                    Blah()
        |]
        actual = MessageTransformer([| Bar() |], [| AnotherMessageTransformer |], [| Blah |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def MessageWithArg():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    i = message.Arguments[0] as int
                    FooMessage(i)
        |]
        actual = MessageTransformer([| Msg(i as int) |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def MessageWithTwoArgs():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    i = message.Arguments[0] as int
                    j = message.Arguments[1] as string
                    FooMessage(i, j)
        |]
        actual = MessageTransformer([| Msg(i as int, j as string) |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessage():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    FooMessage()
        |]
        actual = MessageTransformer([| Msg.Msg2 |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessageWithOneArgAPiece():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    a = message.Arguments[0] as int
                    b = message.ChildMessage.Arguments[0] as char
                    FooMessage(a, b)
        |]
        actual = MessageTransformer([| Msg(a as int).Msg2(b as char) |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def ThreePartMessageWithCrazyStuff():
        expected = [|
            def CrazyTransformer(message as Pantheon.Message):
                try:
                    i = message.ChildMessage.Arguments[0] as int
                    hello = message.ChildMessage.ChildMessage.Arguments[0] as string
                    world = message.ChildMessage.ChildMessage.Arguments[1] as string
                    MyCallback(i, hello, world)
        |]
        actual = MessageTransformer([| My.Awesome(i as int).Message(hello as string, world as string) |], [| CrazyTransformer |], [| MyCallback |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def ManyPartMessage():
        expected = [|
            def CrazyTransformer(message as Pantheon.Message):
                try:
                    a = message.ChildMessage.ChildMessage.Arguments[0] as int
                    b = message.ChildMessage.ChildMessage.Arguments[1] as long
                    c = message.ChildMessage.ChildMessage.Arguments[2] as char
                    d = message.ChildMessage.ChildMessage.ChildMessage.ChildMessage.Arguments[0] as string
                    MyCallback(a, b, c, d)
        |]
        actual = MessageTransformer([| Just.A.Regular(a as int, b as long, c as char).EveryDay.Normal(d as string).Guy |], [| CrazyTransformer |], [| MyCallback |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))
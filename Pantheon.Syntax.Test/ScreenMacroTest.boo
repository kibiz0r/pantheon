import NUnit.Framework
import System.Linq.Enumerable
import Pantheon.EnumerableExtensions

[TestFixture]
class ScreenMacroTest:
    view SomeView:
        pass

    screen My:
        label Wat

    screen MyWithViewContext:
        view_context SomeView:
            graphic InSomeView

    screen as MyScreen
    screenWithViewContext as MyWithViewContextScreen

    [SetUp]
    def SetUp():
        screen = MyScreen()

    [Test]
    def DeclaringWidget():
        widgets = (LabelWidget,)
        Assert.That(screen.Wat isa LabelWidget)
        Assert.That(screen.Widgets.Types(), Is.EquivalentTo(widgets))

    [Test]
    def DeclaringWidgetInViewContext():
        widgets = (GraphicWidget,)
        Assert.That(screenWithViewContext.InSomeView isa GraphicWidget)
        Assert.That(screenWithViewContext.Widgets.Types(), Is.EquivalentTo(widgets))
        #Assert.That(screenWithViewContext.InSomeView.View isa SomeViewView)
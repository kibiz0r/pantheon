namespace Pantheon.Syntax.Test

import System
import NUnit.Framework

[TestFixture]
class WidgetPropertyLinks():
    [Test]
    def WidgetPropertyGeneration():
        block = [|
            block:
                text: "Score: ${View.Player.Score} points"
        |].Body
        properties = WidgetPropertyLinksFromBlock(block)
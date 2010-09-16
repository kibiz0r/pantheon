import System
import Boo.Lang.Compiler.Ast
import Boo.Lang.PatternMatching

macro controller(name as ReferenceExpression):
    klassName = "${name}Controller"
    klass = [|
        class $(klassName) (Pantheon.Controller):
            pass
    |]
    //klass.Members.Add(controller["message"])
    yield klass

    macro message:
        case [|message $(ReferenceExpression(Name: name))|]:
            methodName = "${name}Message"
            method = [|
                [Pantheon.MessageAttribute]
                def $(methodName)():
                    pass
            |]
            controller["message"] = method
#            controller["messages"] = controller["messages"] or []
#            controller["messages"].Add(method)

class Foo:
    pass
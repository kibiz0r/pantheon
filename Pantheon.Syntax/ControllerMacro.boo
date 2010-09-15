import System
import Boo.Lang.Compiler.Ast
import Boo.Lang.PatternMatching

macro controller(name as ReferenceExpression):
    klassName = "${name}Controller"
    klass = [|
        class $(ReferenceExpression(klassName)) (Controller):
            pass
    |]
    yield klass
import System
import Boo.Lang.Compiler.Ast
import Boo.Lang.PatternMatching

macro actor(name as ReferenceExpression):
    klassName = "${name}Actor"
    klass = [|
        class $(ReferenceExpression(klassName)) (Actor):
            pass
    |]
    yield klass
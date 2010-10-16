import System
import Boo.Lang.Compiler.Ast
import Boo.Lang.PatternMatching

macro controller(name as ReferenceExpression):
    klassName = MakeControllerType(name.Name)
    klass = [|
        class $(klassName) (Pantheon.Controller):
            pass
    |]
    if controller["messages"]:
        for message in controller["messages"]:
            klass.Members.Add(message)
    yield klass

    macro message:
        case [|message $(ReferenceExpression(Name: name))|]:
            methodName = "message_${name}"
            method = [|
                [Pantheon.MessageAttribute(Name: $(name))]
                def $(methodName)():
                    $(message.Body)
            |]
            controller["messages"] = controller["messages"] or []
            (controller["messages"] as List[of object]).Add(method)
        case [|message $signature|]:
            name = NameFromSignature(signature)
            methodName = "message_${name}"
            method = [|
                [Pantheon.MessageAttribute(Name: $(name))]
                def $(methodName)():
                    $(message.Body)
            |]
            method.Parameters.Extend(ParametersFromSignature(signature))
            controller["messages"] = controller["messages"] or []
            (controller["messages"] as List[of object]).Add(method)
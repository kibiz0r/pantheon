macro describe_controller(name as ReferenceExpression):
    klassName = "describe_controller_${name}"
    controllerName = "controller_${name}"
    klass = [|
        [NUnit.Framework.TestFixture]
        class $(klassName) (Pantheon.ControllerTest[of $(controllerName)]):
            pass
    |]
    if describe_controller["whens"]:
        for when in describe_controller["whens"]:
            print(when)
            klass.Members.Add(when)
    yield klass

    macro when:
        case [|when $(ReferenceExpression(Name: name))|]:
            methodName = "when_${name}"
            method = [|
                [NUnit.Framework.Test]
                def $(methodName)():
                    $(when.Body)
            |]
            describe_controller["whens"] = describe_controller["whens"] or []
            (describe_controller["whens"] as List[of object]).Add(method)
        case [|when $signature|]:
            whenName = nameFromSignature(signature)
            methodName = "when_${whenName}"
            method = [|
                [NUnit.Framework.Test]
                def $(methodName)():
                    $(when.Body)
            |]
            method.Parameters.Extend(parametersFromSignature(signature))
            describe_controller["whens"] = describe_controller["whens"] or []
            (describe_controller["whens"] as List[of object]).Add(method)

def nameFromSignature(signature as MethodInvocationExpression):
    match signature.Target:
        case ReferenceExpression(Name: name):
            return name

def parametersFromSignature(signature as MethodInvocationExpression):
    for arg in signature.Arguments:
        match arg:
            case [| $(ReferenceExpression(Name: name)) as $type |]:
                yield ParameterDeclaration(Name: name, Type: type)
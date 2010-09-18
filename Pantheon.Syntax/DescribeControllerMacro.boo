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
            klass.Members.Add(when)
    yield klass

    macro when:
        case [|when $(ReferenceExpression(Name: name))|]:
            messageName = "message_${name}"
            methodName = "when_${name}"
            method = [|
                [NUnit.Framework.Test]
                def $(methodName)():
                    $(MethodInvocationExpression(MemberReferenceExpression(ReferenceExpression("Controller"), messageName)))
                    $(when.Body)
            |]
            describe_controller["whens"] = describe_controller["whens"] or []
            (describe_controller["whens"] as List[of object]).Add(method)
        case [|when $signature|]:
            arguments = ArgumentsFromSignature(signature)
            name = NameFromSignature(signature)
            messageName = "message_${name}"
            methodName = "when_${name}"
            method = [|
                [NUnit.Framework.Test]
                def $(methodName)():
                    $(MethodInvocationExpression(Target: MemberReferenceExpression(ReferenceExpression("Controller"), messageName), Arguments: arguments))
                    $(when.Body)
            |]
            describe_controller["whens"] = describe_controller["whens"] or []
            (describe_controller["whens"] as List[of object]).Add(method)
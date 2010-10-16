import System.Linq.Enumerable

macro describe_controller(name as ReferenceExpression):
    klassName = "describe_controller_${name}"
    controllerName = MakeControllerType(name.Name)
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
            argumentSuffix = ""
            if arguments.Any():
                argumentSuffix = "_" + String.Join("_", array(string, (argument as LiteralExpression).ValueObject.ToString() for argument in arguments))
            methodName = "when_${name}${argumentSuffix}"
            // Make sure we don't collide
            describe_controller["when_names"] = describe_controller["when_names"] or []
            originalMethodName = methodName
            collisionIndex = 0
            while (describe_controller["when_names"] as List[of object]).Contains(methodName):
                collisionIndex++
                methodName = "${originalMethodName}_${collisionIndex}"
            (describe_controller["when_names"] as List[of object]).Add(methodName)
            method = [|
                [NUnit.Framework.Test]
                def $(methodName)():
                    $(MethodInvocationExpression(Target: MemberReferenceExpression(ReferenceExpression("Controller"), messageName), Arguments: arguments))
                    $(when.Body)
            |]
            describe_controller["whens"] = describe_controller["whens"] or []
            (describe_controller["whens"] as List[of object]).Add(method)
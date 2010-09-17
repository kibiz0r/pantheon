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

    macro when(name as ReferenceExpression):
        methodName = "when_${name}"
        method = [|
            [NUnit.Framework.Test]
            def $(methodName)():
                $(when.Body)
        |]
        describe_controller["whens"] = describe_controller["whens"] or []
        (describe_controller["whens"] as List[of object]).Add(method)
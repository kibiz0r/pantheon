macro describe_controller(name as ReferenceExpression):
    klassName = "${name}ControllerTest"
    klass = [|
        [NUnit.Framework.TestFixture]
        class $(klassName):
            pass
    |]
    yield klass
macro view:
    case [| view $(MethodInvocationExpression(Target: target, Arguments: arguments)) |]:
        worldTypeName = (arguments[0] as ReferenceExpression).Name
        worldType = MakeWorldType(worldTypeName)
        klass = [|
            class $(target) (Pantheon.View[of $(worldType)]):
                $(view.Body)
        |]
        yield klass

        macro action:
            pass
macro view:
    case [| view $(ReferenceExpression(Name: name)) |]:
        viewType = MakeViewType(name)
        klass = [|
            class $(viewType) (Pantheon.View):
                $(view.Body)
        |]
        yield klass

    case [| view $(MethodInvocationExpression(Target: ReferenceExpression(Name: name), Arguments: arguments)) |]:
        viewType = MakeViewType(name)
        worldTypeName = (arguments[0] as ReferenceExpression).Name
        worldType = MakeWorldType(worldTypeName)
        klass = [|
            [Pantheon.RequiresWorldAttribute($(ReferenceExpression(worldType)))]
            class $(viewType) (Pantheon.View):
                $(view.Body)
        |]
        yield klass

        macro action:
            pass
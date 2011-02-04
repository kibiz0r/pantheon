macro actor(name as ReferenceExpression):
    klass = [|
        class $(name) (Pantheon.Actor):
            pass
    |]
    for method in actor.Get("methods"):
        klass.Members.Add(method)
    yield klass

    macro when:
        case [| when $controller |]:
            method = [|
                def when():
                    pass
            |]
            actor.Add("methods", method)
        otherwise:
            pass
macro actor(name as ReferenceExpression):
    klass = [|
        class $(name) (Pantheon.Actor):
            pass
    |]
    klass.Members.Add(actor["method"])
    yield klass

    macro when:
        case [| when $controller |]:
            method = [|
                def when():
                    pass
            |]
            actor["method"] = method
        otherwise:
            pass
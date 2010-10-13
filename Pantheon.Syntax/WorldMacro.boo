macro world:
    case [| world $(ReferenceExpression(Name: name)) |]:
        worldType = MakeWorldType(name)
        klass = [|
            class $(worldType) (Pantheon.World):
                pass
        |]
        yield klass
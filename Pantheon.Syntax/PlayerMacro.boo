macro player:
    case [| player $(ReferenceExpression(Name: name)) |]:
        playerType = MakePlayerType(name)
        klass = [|
            class $(playerType) (Pantheon.Player):
                pass
        |]
        yield klass
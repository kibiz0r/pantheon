macro view:
    case [| view $(ReferenceExpression(Name: name)) |]:
        viewType = MakeViewType(name)
        klass = [|
            class $(viewType) (Pantheon.View):
                def constructor():
                    pass

                $(view.Body)
        |]
        for requiredWorld as string in view.Get("requires_world"):
            attribute = Boo.Lang.Compiler.Ast.Attribute("Pantheon.RequiresWorldAttribute")
            attribute.Arguments.Add(ReferenceExpression(requiredWorld))
            klass.Attributes.Add(attribute)
        for startedPlayer as string in view.Get("starts_player"):
            attribute = Boo.Lang.Compiler.Ast.Attribute("Pantheon.StartsPlayerAttribute")
            attribute.Arguments.Add(ReferenceExpression(startedPlayer))
            klass.Attributes.Add(attribute)
        yield klass

        macro action:
            pass

        macro requires_world:
            case [| requires_world $(ReferenceExpression(Name: worldName)) |]:
                worldType = MakeWorldType(worldName)
                view.Add("requires_world", worldType)

        macro starts_player:
            case [| starts_player $(ReferenceExpression(Name: playerName)) |]:
                playerType = MakePlayerType(playerName)
                view.Add("starts_player", playerType)
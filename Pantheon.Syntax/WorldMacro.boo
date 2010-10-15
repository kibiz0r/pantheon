macro world:
    case [| world $(ReferenceExpression(Name: name)) |]:
        worldType = MakeWorldType(name)
        klass = [|
            class $(worldType) (Pantheon.World):
                pass
        |]
        for when as Method in world.Get("whens"):
            klass.Members.Add(when)
        yield klass

        macro when:
            case [| when $(MemberReferenceExpression(Target: target, Name: name)) |]:
                method = [|
                    override def $(name)():
                        $(when.Body)
                |]
                world.Add("whens", method)

                macro create:
                    case [| create $(ReferenceExpression(Name: actorType)) |]:
                        yield [|
                            Pantheon.ActorFactory.CreateActor[of $(ReferenceExpression(actorType))]()
                        |]
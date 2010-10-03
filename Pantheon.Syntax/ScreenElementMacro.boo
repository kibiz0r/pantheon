macro screen_element(referenceExpression as ReferenceExpression):
    for arg in screen_element.Arguments:
        print(arg)
    #case [| screen_element $(ReferenceExpression(Name: klassName)) |]:
    klassName = "${referenceExpression.Name}ScreenElement"
    klass = [|
        class $(klassName) (Pantheon.ScreenElement):
            $(screen_element.Body)
    |]
    #typeMembers = TypeMembersForClassFromBlock(klass, screen_element.Body)
    #klass.Members.Extend(typeMembers)
    yield klass
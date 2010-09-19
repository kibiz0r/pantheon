macro screen(name as ReferenceExpression):
    klassName = "screen_${name}"
    klass = [|
        class $(klassName) (Pantheon.Screen):
            def constructor():
                pass
    |]
    for element in screen.Get("elements"):
        klass.GetConstructor(0).Body.Add(element as Expression)
    yield klass

    macro world(name as ReferenceExpression):
        pass

    macro label(text as string):
        element = [|
            Elements.Add(Pantheon.Label($(text)))
        |]
        screen.Add("elements", element)
macro screen_element(referenceExpression as ReferenceExpression):
    klassName = "${referenceExpression.Name}ScreenElement"
    klass = [|
        class $(klassName) (Pantheon.ScreenElement):
            $(screen_element.Body)
    |]
    yield klass
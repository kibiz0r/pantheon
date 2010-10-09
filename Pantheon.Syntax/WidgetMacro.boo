macro widget(referenceExpression as ReferenceExpression):
    klassName = "${referenceExpression.Name}Widget"
    klass = [|
        class $(klassName) (Pantheon.Widget):
            $(widget.Body)
    |]
    yield klass
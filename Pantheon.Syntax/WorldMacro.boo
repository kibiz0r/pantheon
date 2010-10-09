macro wat(name as ReferenceExpression):
    typeName = MakeWorldType(name.Name)
    klass = [|
        class $(typeName) (Pantheon.World):
            $(wat.Body)
    |]
    yield klass
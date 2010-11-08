macro receive:
    case [| receive $(lvalue = ReferenceExpression()) = $(rvalue = ReferenceExpression()) |]:
        yield [| $lvalue = Pantheon.Universe.Current.Receive() as duck |]

    case [| receive $expr |]:
        print expr
        yield [| $lvalue = Pantheon.Universe.Current.Receive() as duck |]
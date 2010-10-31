def MessageExpression(root as Expression):
    return [| Message(MessageComponent("Foo")) |]
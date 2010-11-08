controller Actor:
    message Update(elapsed as single):
        pass

    message AnyMessage(message as Message):
        pass

    message (actor as Actor).MoveUp:
        pass

    message (actor as Actor).MoveDown:
        pass

    message (actor as Actor).MoveLeft:
        pass

    message (actor as Actor).MoveRight:
        pass
class Weapon:
    pass

controller Player:
    model Player:
        Name as string

        model Actor:
            model Weapon:
                pass
            # equivalent to
            # message (player as Player)._(actor as Actor).Attack(enemy as Actor).With(weapon as Weapon):
            # in controller context
            message Attack(enemy as Actor).With(weapon as Weapon):
                pass

            # generic Attack.* syntax
            message Attack(enemy as Actor).@:
                pass

    message Create:
        pass

    message player.MoveUp:
        pass

    message player.MoveDown:
        pass

    message player.MoveLeft:
        pass

    message player.MoveRight:
        pass

    message (player as Player)._(actor as Actor).Attacks(enemy as Actor).With(weapon as Weapon):
        pass
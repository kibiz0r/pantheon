controller InjusticeLeague:
    model Superpower:
        Damage as int

    model Superhero:
        Superpower as Superpower

    model Villain:
        RealName as string
        Health as int
        Superpower as Superpower

    message (hero as Superhero).Uses(power as Superpower).On(villain as Villain):
        villain.Health -= power.Damage

    message (villain as Villain).Uses(power as Superpower).On(hero as Superhero):
        pass

    message (villain as Villain).Sees(hero as Superhero):
        send villain.Uses(villain.Superpower).On(hero)
controller JusticeLeague:
    model Superpower:
        Damage as int

    model Superhero:
        RealName as string
        Health as int
        Superpower as Superpower

    model Villain:
        Superpower as Superpower

    message (hero as Superhero).Uses(power as Superpower).On(villain as Villain):
        pass

    message (villain as Villain).Uses(power as Superpower).On(hero as Superhero):
        hero.Health -= power.Damage
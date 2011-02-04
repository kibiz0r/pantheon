world Game (Physics, Actor):
    when (player as Player).Joins:
        create player.PacMan

    when (pacMan as PacMan).Dies:
        send pacMan.Respawns
        send Ghost.All.Reset
world Game (Physics, Actor):
    when Game.Starts:
        print "Game started"
        create PacMan

    when PacMan.CollidesWith(ghost as Ghost):
        pass
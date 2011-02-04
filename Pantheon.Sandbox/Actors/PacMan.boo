actor PacMan:
    setting Speed as single

    when (self).CollidesWith(ghost as Ghost):
        send self.Dies
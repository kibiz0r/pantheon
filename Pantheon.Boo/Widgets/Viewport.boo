import Pantheon

widget Viewport:
    override def Render():
        for sprite in View.Sprites:
            sprite.Render()
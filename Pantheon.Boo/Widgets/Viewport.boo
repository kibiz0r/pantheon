import Pantheon

widget Viewport:
    def constructor():
        print "Creating Viewport!"
        
    override def Render():
        for sprite in View.Sprites:
            print "Rendering sprite!"
            sprite.Render()
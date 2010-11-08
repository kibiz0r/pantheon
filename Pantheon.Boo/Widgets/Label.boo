widget Label:
    Text as string

    override def Render():
        Application.Font.Draw(Display.Width / 2, Display.Height / 2, FontDrawFlags.AlignCentre, Text or '')
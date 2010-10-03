screen_element Label:
    Text as string

    def constructor(text as string):
        Text = text

    override def Render():
        Application.Font.Draw(Display.Width / 2, Display.Height / 2, FontDrawFlags.AlignCentre, Text)
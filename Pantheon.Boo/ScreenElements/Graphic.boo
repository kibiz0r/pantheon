import AllegroSharp

screen_element Graphic:
    Bitmap as Bitmap

    def Graphic(path as string):
        Bitmap = Image.LoadBitmap("Graphics/${path}.png")

    def Render():
        Bitmap.Draw(Left, Top, DrawFlags.None)
import AllegroSharp

widget Graphic:
    Bitmap as Bitmap

    #def constructor(path as string):
    #    Bitmap = Image.LoadBitmap("Graphics/${path}.png")

    override def Render():
        Bitmap.Draw(Left, Top, DrawFlags.None)
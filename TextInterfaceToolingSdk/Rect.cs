namespace TextInterfaceToolingSdk
{
    public class Rect
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Left { get; set; }
        public int Right { get { return Left + Width; } }
        public int Top { get; set; }
        public int Bottom { get { return Top + Height; } }

        public Rect() : this(0, 0, 0, 0) { }

        public Rect(int x, int y, int width, int height)
        {
            Left = x;
            Top = y;
            Width = width;
            Height = height;
        }
    }
}
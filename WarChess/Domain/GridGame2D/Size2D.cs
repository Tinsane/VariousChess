namespace WarChess.Domain.GridGame2D
{
    public class Size2D
    {
        public Size2D(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
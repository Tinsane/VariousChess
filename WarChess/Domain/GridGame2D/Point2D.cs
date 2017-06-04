namespace WarChess.Domain.GridGame2D
{
    public class Point2D
    {
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public Point2D Direction
        {
            get
            {
                if (X == 0 && Y == 0)
                    return new Point2D(0, 0);
                var gcd = Utilities.GCD(X, Y);
                return new Point2D(X / gcd, Y / gcd);
            }
        }

        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(a.X - b.X, a.Y - b.Y);
        }

        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public static Point2D operator *(Point2D p, int k)
        {
            return new Point2D(p.X * k, p.Y * k);
        }
    }
}
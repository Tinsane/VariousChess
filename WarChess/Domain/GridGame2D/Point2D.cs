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

        public bool Divides(Point2D p)
        {
            if (X == 0 && Y == 0)
                return false;
            var coef = X == 0 ? p.Y / Y : p.X / X;
            return this * coef == p;
        }

        public static Point2D operator -(Point2D a, Point2D b) => new Point2D(a.X - b.X, a.Y - b.Y);

        public static Point2D operator +(Point2D a, Point2D b) => new Point2D(a.X + b.X, a.Y + b.Y);

        public static Point2D operator *(Point2D p, int k) => new Point2D(p.X * k, p.Y * k);

        public static explicit operator GridPosition2D(Point2D p) => new GridPosition2D(p.X, p.Y);

        public static bool operator ==(Point2D a, Point2D b) => !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(Point2D a, Point2D b) => !(a == b);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) ||
                !(obj is Point2D))
                return false;
            return Equals((Point2D) obj);
        }

        public bool Equals(Point2D other) => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
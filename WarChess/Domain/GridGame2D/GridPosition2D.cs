using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public class GridPosition2D : IPosition
    {
        public GridPosition2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public static explicit operator Point2D(GridPosition2D gridPosition) => new Point2D(gridPosition.X,
            gridPosition.Y);

        public static bool operator ==(GridPosition2D a, GridPosition2D b)
            => !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(GridPosition2D a, GridPosition2D b) => !(a == b);

        protected bool Equals(GridPosition2D other) => X == other.X && Y == other.Y;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GridPosition2D)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
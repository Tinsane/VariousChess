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
    }
}
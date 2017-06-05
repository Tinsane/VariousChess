using System;
using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public class BoundedGridField2D<TCell>
        : IField<GridPosition2D, TCell>
        where TCell : ICell
    {
        public BoundedGridField2D(int rowsCnt, int columnsCnt) : this(rowsCnt, columnsCnt, new Point2D(0, 0))
        {
        }

        public BoundedGridField2D(int rowsCnt, int columnsCnt, Point2D center)
        {
            Grid = new TCell[rowsCnt, columnsCnt];
            Center = center;
        }

        private Point2D Center { get; }

        private TCell[,] Grid { get; }

        public TCell this[int x, int y]
        {
            get
            {
                x -= Center.X;
                y -= Center.Y;
                if (!Utilities.IsInInterval(x, 0, Grid.GetLength(0)))
                    throw new ArgumentOutOfRangeException(nameof(x));
                if (!Utilities.IsInInterval(y, 0, Grid.GetLength(1)))
                    throw new ArgumentOutOfRangeException(nameof(y));
                return Grid[x, y];
            }
        }

        public Size2D Size => new Size2D(Grid.GetLength(0), Grid.GetLength(1));

        public TCell this[GridPosition2D position] => Grid[position.X, position.Y];
    }
}
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    internal class ChessBoard : BoundedGridField2D<ChessCell>
    {
        public ChessBoard(ChessCell[,] grid) : base(grid, new Point2D(0, 0)) { }

        protected ChessBoard(BoundedGridField2D<ChessCell> field) : base(field) { }

        public override BoundedGridField2D<ChessCell> GetWith(ChessCell cell, GridPosition2D position)
            => new ChessBoard(base.GetWith(cell, position));
    }
}
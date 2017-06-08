using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    public class ChessBoard : BoundedGridField2D<ChessCell>
    {
        public ChessBoard(int rowsCnt, int columnsCnt) : base(rowsCnt, columnsCnt) { }

        protected ChessBoard(ChessCell[,] grid, Point2D center) : base(grid, center) { }

        protected ChessBoard(BoundedGridField2D<ChessCell> field) : base(field) { }

        public new ChessBoard GetWith(ChessCell cell, GridPosition2D position) => new ChessBoard(base.GetWith(cell,
            position));
    }
}
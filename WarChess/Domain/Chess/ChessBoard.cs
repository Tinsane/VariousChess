using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    public class ChessBoard : BoundedGridField2D<ChessCell>
    {
        public ChessBoard(int rowsCnt, int columnsCnt) : base(rowsCnt, columnsCnt) { }

        protected ChessBoard(BoundedGridField2D<ChessCell> field) : base(field) { }

        public override BoundedGridField2D<ChessCell> GetWith(ChessCell cell, GridPosition2D position)
            => new ChessBoard(base.GetWith(cell, position));
    }
}
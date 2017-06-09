using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    internal class ChessBoard : BoundedGridField2D<ChessCell>, IChessBoard<ChessPiece>
    {
        public ChessBoard(ChessCell[,] grid) : base(grid, new Point2D(0, 0)) { }

        protected ChessBoard(BoundedGridField2D<ChessCell> field) : base(field) { }

        public int RowCount => Size.RowsCnt;
        public int ColumnCount => Size.ColumnsCnt;

        public ChessPiece this[ChessPosition position]
        {
            get
            {
                var gridPosition2D = (GridPosition2D) position;
                return this[gridPosition2D].ContainsPiece ? this[gridPosition2D].Piece : null;
            }
        }

        public override BoundedGridField2D<ChessCell> GetWith(ChessCell cell, GridPosition2D position)
            => new ChessBoard(base.GetWith(cell, position));
    }
}
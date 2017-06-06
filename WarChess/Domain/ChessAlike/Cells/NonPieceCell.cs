using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.ChessAlike.Cells
{
    public abstract class NonPieceCell : NonEmptyCell, IChessAlikeCell
    {
        public int? PieceId => null;
    }
}
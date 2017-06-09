using WarChess.Domain.Checkers.Piece;
using WarChess.Domain.ChessAlike;

namespace WarChess.Domain.Checkers
{
    class CheckerCell : ChessAlikeCell<CheckerPiece>
    {
        public CheckerCell(CheckerPiece piece) : base(piece)
        {
        }
    }
}
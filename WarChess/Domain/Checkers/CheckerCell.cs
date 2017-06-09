using WarChess.Domain.Checkers.Pieces;
using WarChess.Domain.ChessAlike;

namespace WarChess.Domain.Checkers
{
    class CheckerCell : ChessAlikeCell<CheckerPiece>
    {
        public CheckerCell(CheckerPiece piece = null) : base(piece)
        {
        }
    }
}
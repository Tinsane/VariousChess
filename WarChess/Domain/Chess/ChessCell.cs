using WarChess.Domain.ChessAlike;

namespace WarChess.Domain.Chess
{
    public class ChessCell : ChessAlikeCell
    {
        public ChessCell(IPiece piece = null) : base(piece) { }
    }
}
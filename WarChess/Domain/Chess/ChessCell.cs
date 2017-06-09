using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike;

namespace WarChess.Domain.Chess
{
    public class ChessCell : ChessAlikeCell<ChessPiece>
    {
        public ChessCell(ChessPiece piece = null) : base(piece) { }
    }
}
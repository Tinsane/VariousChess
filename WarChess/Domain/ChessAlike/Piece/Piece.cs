using WarChess.Domain.AbstractGame.Cells;
using WarChess.Domain.ChessAlike.Cells;

namespace WarChess.Domain.ChessAlike.Piece
{
    public abstract class Piece : NonEmptyCell, IChessAlikeCell
    {
        protected Piece(int pieceId, int playerId)
        {
            PieceId = pieceId;
            PlayerId = playerId;
        }

        private int PlayerId { get; }
        public int? PieceId { get; }
    }
}
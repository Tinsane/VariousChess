using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.ChessAlike.Piece
{
    public abstract class Piece : NonEmptyCell
    {
        protected Piece(int pieceId, int playerId)
        {
            PieceId = pieceId;
            PlayerId = playerId;
        }

        public int PlayerId { get; }
        public int PieceId { get; }
    }
}
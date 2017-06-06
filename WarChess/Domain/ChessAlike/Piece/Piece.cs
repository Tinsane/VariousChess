using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.ChessAlike.Piece
{
    public abstract class Piece : NonEmptyCell
    {
        protected Piece(int typeId, int playerId)
        {
            TypeId = typeId;
            PlayerId = playerId;
        }

        private int PlayerId { get; }
        private int TypeId { get; }
    }
}
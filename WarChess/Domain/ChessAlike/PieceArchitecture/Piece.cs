using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.ChessAlike.PieceArchitecture
{
    public class Piece : ICell
    {
        public Piece(int pieceId, int playerId)
        {
            PieceId = pieceId;
            PlayerId = playerId;
        }

        int PlayerId { get; }
        int PieceId { get; }
    }
}
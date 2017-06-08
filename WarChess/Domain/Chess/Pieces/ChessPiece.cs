using WarChess.Domain.ChessAlike;

namespace WarChess.Domain.Chess.Pieces
{
    public abstract class ChessPiece : IPiece
    {
        protected ChessPiece(int playerId) { PlayerId = playerId; }

        public int PlayerId { get; }

        public abstract void AcceptVisitor(IChessPieceVisitor visitor);
    }
}
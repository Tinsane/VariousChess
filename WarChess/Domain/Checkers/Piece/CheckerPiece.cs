using WarChess.Domain.ChessAlike;

namespace WarChess.Domain.Checkers.Piece
{
    public abstract class CheckerPiece : IPiece
    {
        protected CheckerPiece(int playerId) { PlayerId = playerId; }
        public int PlayerId { get; }

        public abstract void AcceptVisitor(ICheckerPieceVisitor visitor);
    }
}
namespace WarChess.Domain.Chess.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(int playerId, bool wasMove) : base(playerId) { WasMove = wasMove; }

        public bool WasMove { get; }

        protected override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }
    }
}
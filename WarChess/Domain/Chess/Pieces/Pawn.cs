namespace WarChess.Domain.Chess.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(int playerId, bool wasMoved) : base(playerId) { WasMoved = wasMoved; }

        public bool WasMoved { get; }

        protected override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }
    }
}
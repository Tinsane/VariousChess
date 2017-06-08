namespace WarChess.Domain.Chess.Pieces
{
    public class King : ChessPiece
    {
        public King(int playerId, bool wasMoved) : base(playerId) { WasMoved = wasMoved; }

        public bool WasMoved { get; }

        public override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }
    }
}
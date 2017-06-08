namespace WarChess.Domain.Chess.Pieces
{
    public class Queen : ChessPiece
    {
        public Queen(int playerId) : base(playerId) { }

        public override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }
    }
}
namespace WarChess.Domain.Chess.Pieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(int playerId) : base(playerId) { }

        protected override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }
    }
}
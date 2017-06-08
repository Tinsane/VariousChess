namespace WarChess.Domain.Chess.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(int playerId) : base(playerId) { }

        protected override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }
    }
}
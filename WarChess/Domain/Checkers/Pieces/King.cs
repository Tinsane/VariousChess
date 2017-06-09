namespace WarChess.Domain.Checkers.Pieces
{
    public class King : CheckerPiece
    {
        public King(int playerId) : base(playerId)
        {
        }

        public override void AcceptVisitor(ICheckerPieceVisitor visitor) { visitor.Visit(this); }
    }
}
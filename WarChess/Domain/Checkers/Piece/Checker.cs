namespace WarChess.Domain.Checkers.Piece
{
    public class Checker : CheckerPiece
    {
        public Checker(int playerId) : base(playerId)
        {
        }

        public override void AcceptVisitor(ICheckerPieceVisitor visitor) { visitor.Visit(this); }
    }
}
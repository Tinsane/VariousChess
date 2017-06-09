namespace WarChess.Domain.Checkers.Piece
{
    public interface ICheckerPieceVisitor
    {
        void Visit(Checker checker);
        void Visit(King king);
    }
}
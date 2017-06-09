namespace WarChess.Domain.Checkers.Pieces
{
    public interface ICheckerPieceVisitor
    {
        void Visit(Checker checker);
        void Visit(King king);
    }
}
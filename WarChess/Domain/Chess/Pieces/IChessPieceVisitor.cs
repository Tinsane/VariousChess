namespace WarChess.Domain.Chess.Pieces
{
    public interface IChessPieceVisitor
    {
        void Visit(Bishop bishop);
        void Visit(King king);
        void Visit(Queen queen);
        void Visit(Knight knight);
        void Visit(Pawn pawn);
        void Visit(Rook rook);
    }
}
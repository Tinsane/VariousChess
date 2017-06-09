namespace WarChess.Domain.Chess.Pieces.Visitors
{
    public class KingCheckVisitor : IChessPieceVisitor
    {
        private static readonly KingCheckVisitor Visitor = new KingCheckVisitor();
        private bool checkResult;

        private KingCheckVisitor() { }
        public void Visit(Bishop bishop) { checkResult = false; }

        public void Visit(King king) { checkResult = true; }

        public void Visit(Queen queen) { checkResult = false; }

        public void Visit(Knight knight) { checkResult = false; }

        public void Visit(Pawn pawn) { checkResult = false; }

        public void Visit(Rook rook) { checkResult = false; }

        public static bool IsKing(ChessPiece piece)
        {
            piece.AcceptVisitor(Visitor);
            return Visitor.checkResult;
        }
    }
}
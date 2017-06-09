namespace WarChess.Domain.Chess.Pieces.Visitors
{
    internal class RookCheckVisitor : IChessPieceVisitor
    {
        private static readonly RookCheckVisitor Visitor = new RookCheckVisitor();
        private bool checkResult;

        private RookCheckVisitor() { }
        public void Visit(Bishop bishop) { checkResult = false; }

        public void Visit(King king) { checkResult = false; }

        public void Visit(Queen queen) { checkResult = false; }

        public void Visit(Knight knight) { checkResult = false; }

        public void Visit(Pawn pawn) { checkResult = false; }

        public void Visit(Rook rook) { checkResult = true; }

        public static bool IsRook(ChessPiece piece)
        {
            piece.AcceptVisitor(Visitor);
            return Visitor.checkResult;
        }
    }
}
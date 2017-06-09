namespace WarChess.Domain.Chess.Pieces.Visitors
{
    class PawnCheckVisitor : IChessPieceVisitor
    {
        private static readonly PawnCheckVisitor Visitor = new PawnCheckVisitor();
        private bool checkResult;

        private PawnCheckVisitor() { }
        public void Visit(Bishop bishop) { checkResult = false; }

        public void Visit(King king) { checkResult = false; }

        public void Visit(Queen queen) { checkResult = false; }

        public void Visit(Knight knight) { checkResult = false; }

        public void Visit(Pawn pawn) { checkResult = true; }

        public void Visit(Rook rook) { checkResult = false; }

        public static bool IsPawn(ChessPiece piece)
        {
            piece.AcceptVisitor(Visitor);
            return Visitor.checkResult;
        }
    }
}
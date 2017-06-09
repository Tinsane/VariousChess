using System;
using WarChess.Domain.Chess.Pieces;

namespace WarChess.Domain.Chess.Moves.Visitors
{
    public class WasMovedVisitor : IChessPieceVisitor
    {
        private static readonly WasMovedVisitor Visitor = new WasMovedVisitor();
        private bool wasMoved;

        private WasMovedVisitor() { }

        public void Visit(Bishop bishop) { throw new ArgumentException(); }

        public void Visit(King king) { wasMoved = king.WasMoved; }

        public void Visit(Queen queen) { throw new ArgumentException(); }

        public void Visit(Knight knight) { throw new ArgumentException(); }

        public void Visit(Pawn pawn) { wasMoved = pawn.WasMoved; }

        public void Visit(Rook rook) { wasMoved = rook.WasMoved; }

        public static bool WasMoved(ChessPiece piece)
        {
            piece.AcceptVisitor(Visitor);
            return Visitor.wasMoved;
        }
    }
}
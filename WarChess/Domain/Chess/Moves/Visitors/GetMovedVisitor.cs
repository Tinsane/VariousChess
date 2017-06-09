using System;
using WarChess.Domain.Chess.Pieces;

namespace WarChess.Domain.Chess.Moves.Visitors
{
    public class GetMovedVisitor : IChessPieceVisitor
    {
        private static readonly GetMovedVisitor Visitor = new GetMovedVisitor();
        private ChessPiece piece;
        private GetMovedVisitor() { }
        public void Visit(Bishop bishop) { throw new ArgumentException(); }

        public void Visit(King king) { piece = new King(king.PlayerId, true); }

        public void Visit(Queen queen) { throw new ArgumentException(); }

        public void Visit(Knight knight) { throw new ArgumentException(); }

        public void Visit(Pawn pawn) { piece = new Pawn(pawn.PlayerId, true, pawn.Transformer); }

        public void Visit(Rook rook) { piece = new Rook(rook.PlayerId, true); }

        public static ChessPiece GetMoved(ChessPiece piece)
        {
            piece.AcceptVisitor(Visitor);
            return Visitor.piece;
        }
    }
}
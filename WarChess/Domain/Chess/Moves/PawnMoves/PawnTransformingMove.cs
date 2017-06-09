using System;
using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public class PawnTransformingMove : PawnMove
    {
        private readonly Func<ChessPiece, ChessPiece> transformer;

        public PawnTransformingMove(int pawnOwnerId, Point2D step, GridPosition2D from, GridPosition2D to,
            Func<ChessPiece, ChessPiece> transformer) : base(pawnOwnerId, step, from, to)
        {
            this.transformer = transformer;
        }

        protected new ChessGameState Apply(ChessGameState gameState)
        {
            if (PawnOwnerId == Utils.WhitePlayerId && To.X == gameState.Field.Size.RowsCnt - 1 ||
                PawnOwnerId == Utils.BlackPlayerId && To.X == 0)
                return gameState.MovePiece(From, To,
                    pawn => transformer(GetMovedVisitor.GetMoved(pawn)));
            return gameState.MovePiece(From, To, GetMovedVisitor.GetMoved);
        }
    }
}
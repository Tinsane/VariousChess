using System;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public class PawnForwardMove : PawnTransformingMove
    {
        public PawnForwardMove(int pawnOwnerId, GridPosition2D from, GridPosition2D to,
            Func<ChessPiece> transformer) : base(
            pawnOwnerId, new Point2D(1, 0), from, to, transformer)
        {
        }

        protected new bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                !gameState.Field[To].ContainsPiece;
    }
}
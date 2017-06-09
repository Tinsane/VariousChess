using System;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public class PawnCapturing : PawnTransformingMove
    {
        public PawnCapturing(int pawnOwnerId, Point2D step, GridPosition2D from, GridPosition2D to,
            Func<int, ChessPiece> transformer) : base(pawnOwnerId,
            step, from, to, transformer)
        {
        }

        public override bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                  gameState.Field[To].ContainsPiece;
    }
}
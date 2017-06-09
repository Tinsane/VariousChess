﻿using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public class PawnDoubleJump : PawnMove
    {
        public PawnDoubleJump(int pawnOwnerId, GridPosition2D from, GridPosition2D to) : base(pawnOwnerId,
            new Point2D(2, 0), from, to)
        {
        }

        public override bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                !WasMovedVisitor.WasMoved(gameState.Field[From].Piece);
    }
}
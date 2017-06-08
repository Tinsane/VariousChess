using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class PawnDoubleJump : PawnMove
    {
        public PawnDoubleJump(int pawnOwnerId, GridPosition2D from, GridPosition2D to) : base(pawnOwnerId,
            new Point2D(2, 0), from, to)
        {
        }

        protected new bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                !WasMovedVisitor.WasMoved(gameState.Field[From].Piece);
    }
}
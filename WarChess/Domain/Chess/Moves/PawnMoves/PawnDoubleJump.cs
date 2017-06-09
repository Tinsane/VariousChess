using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public class PawnDoubleJump : PawnMove
    {
        public PawnDoubleJump(int pawnOwnerId, GridPosition2D from, GridPosition2D to) : base(pawnOwnerId,
            new Point2D(2, 0), from, to)
        {
        }

        public override bool IsValid(ChessGameState gameState)
        {
            var middleCell = (GridPosition2D) ((Point2D) From + Step / 2);
            return base.IsValid(gameState) &&
                   !gameState.Field[To].ContainsPiece &&
                   !gameState.Field[middleCell].ContainsPiece &&
                   !WasMovedVisitor.WasMoved(gameState.Field[From].Piece);
        }

        protected override ChessGameState Apply(ChessGameState gameState)
        {
            gameState = base.Apply(gameState);
            return new ChessGameState(gameState.Field, gameState.CurrentPlayerId, this);
        }
    }
}
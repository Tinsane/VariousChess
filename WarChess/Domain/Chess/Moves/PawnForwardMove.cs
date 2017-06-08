using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class PawnForwardMove : PawnMove
    {
        public PawnForwardMove(int pawnOwnerId, GridPosition2D from, GridPosition2D to) : base(
            pawnOwnerId, new Point2D(1, 0), from, to)
        {
        }

        // TODO : not implemented transform
        protected new bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                !gameState.Field[To].ContainsPiece;
    }
}
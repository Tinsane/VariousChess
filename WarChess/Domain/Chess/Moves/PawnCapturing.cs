using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class PawnCapturing : PawnMove
    {
        public PawnCapturing(int pawnOwnerId, Point2D step, GridPosition2D from, GridPosition2D to) : base(pawnOwnerId,
            step, from, to)
        {
        }

        // TODO : not implemented transform
        protected new bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                gameState.Field[To].ContainsPiece;
    }
}
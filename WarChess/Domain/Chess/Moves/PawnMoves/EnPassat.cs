using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public class EnPassat : PawnMove
    {
        public EnPassat(int pawnOwnerId, Point2D step, GridPosition2D from, GridPosition2D to) : base(pawnOwnerId, step,
            from, to)
        {
        }

        public override bool IsValid(ChessGameState gameState)
            => base.IsValid(gameState) &&
               !ReferenceEquals(gameState.PreviousPawnDoubleJump, null) &&
               new GridPosition2D(From.X, To.Y) == gameState.PreviousPawnDoubleJump.To;

        protected override ChessGameState Apply(ChessGameState gameState)
        {
            gameState = base.Apply(gameState);
            return new ChessGameState(gameState.Field.GetWith(new ChessCell(), new GridPosition2D(From.X, To.Y)),
                gameState.CurrentPlayerId);
        }
    }
}
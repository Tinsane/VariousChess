using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public class SlidingMove<TGameState, TCell> : DirectedMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ChessAlikeCell
    {
        public SlidingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to)
        {
        }

        protected override TGameState Apply(TGameState gameState)
        {
            throw new System.NotImplementedException();
        }
    }
}
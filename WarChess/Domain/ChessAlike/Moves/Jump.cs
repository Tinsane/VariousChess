using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public abstract class Jump<TGameState, TCell> : DirectedMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ChessAlikeCell
    {
        protected Jump(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        protected new bool IsValid(TGameState gameState) => base.IsValid(gameState) &&
                                                            (Point2D) To - (Point2D) From == Step;
    }
}
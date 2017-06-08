using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public abstract class Jump<TGameState, TCell, TPiece> : DirectedMove<TGameState, TCell, TPiece>
        where TGameState : ChessAlikeGameState<TCell, TPiece>
        where TCell : ChessAlikeCell<TPiece>
        where TPiece : IPiece
    {
        protected Jump(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        protected new bool IsValid(TGameState gameState) => base.IsValid(gameState) &&
                                                            (Point2D) To - (Point2D) From == Step;
    }
}
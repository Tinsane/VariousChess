using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public abstract class GridGame2D<TGameState>
        : Game<TGameState, BoundedGridField2D, GridPosition2D, SquareCell>
        where TGameState : IGridGameState2D
    {
        protected GridGame2D(TGameState initialState) : base(initialState)
        {
        }
    }
}
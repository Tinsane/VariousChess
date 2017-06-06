using WarChess.Domain.AbstractGame;
using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.GridGame2D
{
    public abstract class GridGame2D<TGameState, TCell>
        : Game<TGameState, BoundedGridField2D<TCell>, GridPosition2D, TCell>
        where TGameState : IGridGameState2D<TCell>
        where TCell : ICell
    {
        protected GridGame2D(TGameState initialState) : base(initialState)
        {
        }
    }
}
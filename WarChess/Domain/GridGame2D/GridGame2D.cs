using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public abstract class GridGame2D : Game<IGridGameState2D, BoundedGridField2D, GridPosition2D>
    {
        protected GridGame2D(IGridGameState2D initialState) : base(initialState)
        {
        }
    }
}
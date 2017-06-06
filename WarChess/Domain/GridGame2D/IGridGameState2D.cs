using WarChess.Domain.AbstractGame;
using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.GridGame2D
{
    public interface IGridGameState2D<TCell>
        : IGameState<BoundedGridField2D<TCell>, GridPosition2D, TCell>
        where TCell : Cell
    {
    }
}
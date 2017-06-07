using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public interface IGridGameState2D<TCell>
        : IGameState<BoundedGridField2D<TCell>, GridPosition2D, TCell>
        where TCell : ICell
    {
    }
}
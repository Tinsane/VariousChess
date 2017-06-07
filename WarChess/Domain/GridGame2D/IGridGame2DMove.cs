using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public interface IGridGame2DMove<TGameState, TCell>
        : IMove<TGameState, BoundedGridField2D<TCell>, GridPosition2D, TCell>
        where TGameState : IGridGameState2D<TCell>
        where TCell : ICell
    {
    }
}
using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    public interface IGridGameState2D : IGameState<BoundedGridField2D, GridPosition2D, SquareCell2D>
    {
    }
}
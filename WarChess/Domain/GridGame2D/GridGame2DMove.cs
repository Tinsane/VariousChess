using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.GridGame2D
{
    internal interface IGridGame2DMove : IMove<IGridGameState2D, BoundedGridField2D, GridPosition2D, SquareCell2D>
    {
    }
}
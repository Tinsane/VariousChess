using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.AbstractGame
{
    public interface IMove<TGameState, TField, TPosition, TCell>
        where TGameState : IGameState<TField, TPosition, TCell>
        where TField : IField<TPosition, TCell>
        where TPosition : IPosition
        where TCell : ICell
    {
        TGameState Make(TGameState gameState);
    }
}
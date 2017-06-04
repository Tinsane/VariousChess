namespace WarChess.Domain.AbstractGame
{
    public interface IMove<TGameState, TField, TPosition>
        where TGameState : IGameState<TField, TPosition>
        where TField : IField<TPosition>
        where TPosition : IPosition
    {
        TGameState Make(TGameState gameState);
    }
}
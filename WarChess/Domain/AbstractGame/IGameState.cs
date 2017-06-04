namespace WarChess.Domain.AbstractGame
{
    public interface IGameState<out TField, in TPosition>
        where TField : IField<TPosition>
        where TPosition : IPosition
    {
        TField Field { get; }
        int CurrentPlayerId { get; }
    }
}
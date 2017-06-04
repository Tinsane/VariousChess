namespace WarChess.Domain.AbstractGame
{
    public interface IField<in TPosition, out TCell>
        where TPosition : IPosition
        where TCell : ICell
    {
        TCell this[TPosition position] { get; }
    }
}
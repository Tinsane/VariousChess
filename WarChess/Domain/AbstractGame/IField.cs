namespace WarChess.Domain.AbstractGame
{
    public interface IField<in TPosition>
        where TPosition : IPosition
    {
        IPiece this[TPosition position] { get; }
    }
}
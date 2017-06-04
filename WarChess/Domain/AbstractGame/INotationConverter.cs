namespace WarChess.Domain.AbstractGame
{
    internal interface INotationConverter<TPosition>
    {
        TPosition FromNotation(string notation);
        string ToNotation(TPosition position);
    }
}
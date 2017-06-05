using WarChess.Domain.WarChess;

namespace WarChess.Domain.Chess
{
    public interface IChessPiece
    {
        Color Color { get; }
        string Name { get; }
    }
}

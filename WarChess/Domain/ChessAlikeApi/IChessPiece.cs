

namespace WarChess.Domain.ChessAlikeApi
{
    // Уровень абстракции повыше ChessAlike, но пониже IWarChessGame
    // Типа, для шашек, шахмат и военок - этого хватит.
    // Если появится стена посреди поля - то уже не хватит.
    public interface IChessPiece
    {
        Color Color { get; }
    }
}

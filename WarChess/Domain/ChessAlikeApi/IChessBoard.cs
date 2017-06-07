namespace WarChess.Domain.ChessAlikeApi
{
    public interface IChessBoard<out TPiece>
    {
        TPiece this[ChessPosition position] { get; }
    }
}

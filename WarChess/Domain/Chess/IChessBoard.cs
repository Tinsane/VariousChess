namespace WarChess.Domain.Chess
{
    public interface IChessBoard<out TPiece>
    {
        TPiece this[ChessPosition position] { get; }
    }
}

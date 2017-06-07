namespace WarChess.Domain.ChessAlikeApi
{
    public interface IChessBoard<out TPiece>
    {
        int RowCount { get; }
        int ColumnCount { get; }
        TPiece this[ChessPosition position] { get; }
    }
}

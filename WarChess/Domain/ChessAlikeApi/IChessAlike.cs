namespace WarChess.Domain.ChessAlikeApi
{
    public interface IChessAlike<out TCell>
    {
        IChessBoard<TCell> Board { get; }
    }
}
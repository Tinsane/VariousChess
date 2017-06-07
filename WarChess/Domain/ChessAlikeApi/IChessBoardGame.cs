namespace WarChess.Domain.ChessAlikeApi
{
    public interface IChessBoardGame<out TCell>
    {
        IChessBoard<TCell> Board { get; }
    }
}
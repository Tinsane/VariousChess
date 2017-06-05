namespace WarChess.Domain.Chess
{
    public interface IChessBoard
    {
        IChessPiece this[ChessPosition position] { get; }
    }
}

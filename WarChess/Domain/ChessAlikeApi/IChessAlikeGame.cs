using WarChess.Domain.Chess;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlikeApi
{
    public interface IChessAlikeGame<out TCell> : IChessBoardGame<TCell>
        where TCell : IChessAlikePiece
    {
        bool IsFinished { get; }
        Color WhoseTurn { get; }
        bool TryMakeMove(ChessPosition from, ChessPosition to);
    }
}
using WarChess.Domain.WarChess;

namespace WarChess.Domain.Chess.GameStateProvider
{
    public interface IWarChessGameStateProvider
    {
        WarChessGameState GetInitialWarGameState();
    }
}
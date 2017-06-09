namespace WarChess.Domain.Chess.GameStateProvider
{
    public interface IChessGameStateProvider
    {
        ChessGameState GetInitialGameState();
    }
}
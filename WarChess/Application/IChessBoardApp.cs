using System;
using WarChess.Domain.Chess;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Application
{
    public interface IChessBoardApp<out TGame, TCell>
        where TGame : IChessBoardGame<TCell>
    {
        TGame Game { get; }
        void ClickAt(ChessPosition position);

        event Action StateChanged; // На это событие мы подпишемся из UserInterface и будем делать перерисовку
    }
}
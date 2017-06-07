using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Application
{
    public interface IChessAlikeApp<out TGame, TCell>
        where TGame : IChessAlike<TCell>
    {
        TGame Game { get; }
        void ClickAt(ChessPosition position);

        event Action StateChanged; // На это событие мы подпишемся из UserInterface и будем делать перерисовку
    }
}

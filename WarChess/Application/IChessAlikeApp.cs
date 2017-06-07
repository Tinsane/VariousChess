using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Application
{
    public interface IChessAlikeApp<out TGame, TCell> : IChessBoardApp<TGame, TCell>
        where TGame : IChessAlikeGame<TCell>
        where TCell : IChessAlikePiece
    {
    }
}

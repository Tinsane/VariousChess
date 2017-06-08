using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.Domain.ChessAlikeApi
{
    public interface IChessAlikeGame<out TCell> : IChessBoardGame<TCell>
        where TCell : IChessAlikePiece
    {
        bool IsFinished { get; }
        Color WhoseTurn { get; }

        /// <summary>
        /// Returns true if move was successful, otherwise returns false.
        /// </summary>
        bool TryMakeMove(ChessPosition from, ChessPosition to);
    }
}

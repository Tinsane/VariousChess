using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.GridGame2D;

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
        bool TryMakeMove(GridPosition2D from, GridPosition2D to);
    }
}

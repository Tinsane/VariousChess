using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.Domain
{
    public interface IGameState
    {
        IField Field { get; }
        int CurrentPlayerId { get; }

        /// <summary>
        /// Returns null if move is invalid.
        /// </summary>
        IGameState MakeMove(Position @from, Position to);
    }
}

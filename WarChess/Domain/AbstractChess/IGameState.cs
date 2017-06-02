using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.Domain
{
    // Если он тебе зачем-то нужен, то ок. Мне он не нужен.
    public interface IGameState
    {
        IField Field { get; }
        int CurrentPlayerId { get; }

        /// <summary>
        /// Returns null if move is invalid.
        /// </summary>
        IGameState MakeMove(Position from, Position to);
    }
}

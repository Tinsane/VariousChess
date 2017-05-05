using System.Collections.Generic;

namespace WarChess.Domain
{
    public interface IGame
    {
        Color WhoseMove { get; }

        // Потенциально ещё тут могут быть методы, для отмены хода и для возврата полной истории ходов.
        // Можно, кстати, совместить эти штуки, реализовав undo/redo, но это всё пока не принцпиально.
        IField Field { get; }

        /// <summary>
        /// If there is no figure in the position or the figure is opposite player's - return empty list.
        /// </summary>
        List<Position> GetPossibleMoves(Position from);
        
        /// <summary>
        /// If the move is inapplicable - throw an exception.
        /// </summary>
        void MakeMove(Position from, Position to);
    }
}

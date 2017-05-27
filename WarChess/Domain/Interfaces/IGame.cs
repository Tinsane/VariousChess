using System.Collections.Generic;

namespace WarChess.Domain
{
    public interface IGame
    {
        Color WhoseMove { get; }

        // Потенциально ещё тут могут быть методы, для отмены хода и для возврата полной истории ходов.
        // Можно, кстати, совместить эти штуки, реализовав undo/redo, но это всё пока не принцпиально.
        IGameState State { get; }

        /// <summary>
        /// If there is no figure in the position or the figure is opposite player's - return empty list.
        /// </summary>
        List<Position> GetPossibleMoves(Position from);

        /// <summary>
        /// Returns true if move was successful, otherwise returns false.
        /// </summary>
        bool TryMakeMove (Position from, Position to);
    }
}

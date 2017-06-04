namespace WarChess.Domain.AbstractChess
{
    // Если он тебе зачем-то нужен, то ок. Мне он не нужен.
    public interface IGameState
    {
        IField Field { get; }
        int CurrentPlayerId { get; }

        /// <summary>
        ///     Returns null if move is invalid.
        /// </summary>
        IGameState MakeMove(Position from, Position to);
    }
}
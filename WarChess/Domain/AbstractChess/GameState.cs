using System;

namespace WarChess.Domain.AbstractChess
{
    internal class GameState : IGameState
    {
        public GameState(IField field, int currentPlayerId)
        {
            Field = field;
            CurrentPlayerId = currentPlayerId;
        }

        public IField Field { get; }
        public int CurrentPlayerId { get; }

        public IGameState MakeMove(Position from, Position to)
        {
            throw new NotImplementedException();
        }
    }
}
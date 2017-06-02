using System;
using System.Collections.Generic;

namespace WarChess.Domain
{
    public class Game
    {
        private readonly Stack<IGameState> states;

        public Game()
        {
            states = new Stack<IGameState>();
            throw new NotImplementedException(); // TODO : add initial state
        }

        public Color WhoseMove
        {
            get { throw new NotImplementedException(); }
        }

        private IGameState State => states.Peek();

        public List<Position> GetPossibleMoves(Position from)
        {
            throw new NotImplementedException();
        }

        public bool TryMakeMove(Position from, Position to)
        {
            var newState = State.MakeMove(from, to);
            if (ReferenceEquals(newState, null))
                return false;
            states.Push(newState);
            return true;
        }
    }
}
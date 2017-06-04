using System.Collections.Generic;

namespace WarChess.Domain.AbstractGame
{
    public abstract class Game<TGameState, TField, TPosition>
        where TGameState : IGameState<TField, TPosition>
        where TField : IField<TPosition>
        where TPosition : IPosition
    {
        private readonly Stack<TGameState> states;

        protected Game(TGameState initialState)
        {
            states = new Stack<TGameState>();
            states.Push(initialState);
        }

        public TGameState State => states.Peek();

        protected bool TryMakeMove(IMove<TGameState, TField, TPosition> move)
        {
            var newState = move.Make(State);
            if (ReferenceEquals(newState, null))
                return false;
            states.Push(newState);
            return true;
        }
    }
}
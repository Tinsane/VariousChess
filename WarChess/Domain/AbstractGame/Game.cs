using System.Collections.Generic;

namespace WarChess.Domain.AbstractGame
{
    public abstract class Game<TGameState, TField, TPosition, TCell> : IGame
        where TGameState : IGameState<TField, TPosition, TCell>
        where TField : IField<TPosition, TCell>
        where TPosition : IPosition
        where TCell : ICell
    {
        private readonly Stack<TGameState> states;

        protected Game(TGameState initialState)
        {
            states = new Stack<TGameState>();
            states.Push(initialState);
        }

        protected TGameState CurrentState => states.Peek();

        protected bool TryMakeMove(IMove<TGameState, TField, TPosition, TCell> move)
        {
            var newState = move.Make(CurrentState);
            if (ReferenceEquals(newState, null))
                return false;
            states.Push(newState);
            return true;
        }
    }
}
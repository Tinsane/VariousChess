using System;
using System.Collections.Generic;
using System.Linq;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike
{
    public abstract class ChessAlikeGame<TGameState, TCell, TPiece>
        : GridGame2D<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell, TPiece>
        where TCell : ChessAlikeCell<TPiece>
        where TPiece : IPiece
    {
        protected ChessAlikeGame(TGameState initialState) : base(initialState) { }

        protected abstract IEnumerable<IChessAlikeMove<TGameState, TCell, TPiece>> GetPossibleMoves(GridPosition2D from,
            GridPosition2D to);

        public bool TryMakeMove(GridPosition2D from, GridPosition2D to)
        {
            if (!CurrentState.Field.Contains(from))
                throw new ArgumentException(nameof(from));
            if (!CurrentState.Field.Contains(to))
                throw new ArgumentException(nameof(to));
            return GetPossibleMoves(from, to).Any(TryMakeMove);
        }
    }
}
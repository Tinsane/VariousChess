using System.Collections.Generic;
using System.Linq;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike
{
    // TODO
    public abstract class ChessAlikeGame<TGameState, TCell>
        : GridGame2D<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ChessAlikeCell
    {
        protected ChessAlikeGame(TGameState initialState) : base(initialState)
        {
        }

        protected abstract IEnumerable<DirectedMove<TGameState, TCell>> GetPossibleMoves(GridPosition2D from,
            GridPosition2D to);

        public bool TryMakeMove(GridPosition2D from, GridPosition2D to)
        {
            return GetPossibleMoves(from, to).Any(TryMakeMove);
        }
    }
}
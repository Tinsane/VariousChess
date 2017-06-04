using WarChess.Domain.AbstractGame;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike
{
    // TODO
    public abstract class ChessAlikeGame<TGameState, TCell>
        : GridGame2D<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ICell
    {
        protected ChessAlikeGame(TGameState initialState) : base(initialState)
        {
        }
    }
}
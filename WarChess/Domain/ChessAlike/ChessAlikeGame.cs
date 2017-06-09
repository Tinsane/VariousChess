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
        public bool IsFinished => !CurrentState.CanCurrentPlayerMove();
    }
}
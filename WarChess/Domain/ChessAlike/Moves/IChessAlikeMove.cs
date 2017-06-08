using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public interface IChessAlikeMove<TGameState, TCell, TPiece> : IGridGame2DMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell, TPiece>
        where TCell : ChessAlikeCell<TPiece>
        where TPiece : IPiece
    {
    }
}
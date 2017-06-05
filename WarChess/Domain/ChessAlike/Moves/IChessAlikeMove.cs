using WarChess.Domain.AbstractGame;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public interface IChessAlikeMove<TGameState, TCell> : IGridGame2DMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ICell
    {
    }
}
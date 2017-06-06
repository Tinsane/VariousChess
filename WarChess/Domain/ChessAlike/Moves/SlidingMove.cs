using System;
using WarChess.Domain.ChessAlike.Cells;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public class SlidingMove<TGameState, TCell> : DirectedMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : IChessAlikeCell
    {
        public SlidingMove(Point2D step, Point2D from, Point2D to) : base(step, from, to)
        {
        }

        public override TGameState Make(TGameState gameState)
        {
            throw new NotImplementedException();
        }
    }
}
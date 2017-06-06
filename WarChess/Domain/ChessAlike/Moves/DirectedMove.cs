using WarChess.Domain.AbstractGame.Cells;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public abstract class DirectedMove<TGameState, TCell> : IChessAlikeMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ICell
    {
        protected DirectedMove(Point2D step, Point2D from, Point2D to)
        {
            Step = step;
            From = from;
            To = to;
        }

        public Point2D Step { get; }
        public Point2D From { get; }

        public Point2D To { get; }

        public abstract TGameState Make(TGameState gameState);
    }
}
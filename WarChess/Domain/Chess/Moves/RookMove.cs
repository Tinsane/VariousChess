using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class RookMove : ChessSlidingMove
    {
        public RookMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        protected override ChessGameState Apply(ChessGameState gameState)
            => gameState.MovePiece(From, To, GetMovedVisitor.GetMoved);
    }
}
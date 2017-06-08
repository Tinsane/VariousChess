using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class ChessJump : Jump<ChessGameState, ChessCell>
    {
        public ChessJump(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        protected override ChessGameState Apply(ChessGameState gameState)
            => gameState.MovePiece(From, To);
    }
}
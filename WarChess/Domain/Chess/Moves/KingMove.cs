using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class KingMove : ChessJump
    {
        public KingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        public new ChessGameState Apply(ChessGameState gameState) => gameState.MovePiece(From, To,
            GetMovedVisitor.GetMoved);
    }
}
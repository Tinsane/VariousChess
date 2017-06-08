using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves
{
    public class ChessSlidingMove : SlidingMove<ChessGameState, ChessCell, ChessPiece>
    {
        public ChessSlidingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        protected override ChessGameState Apply(ChessGameState gameState)
            => gameState.MovePiece(From, To, piece => piece);
    }
}
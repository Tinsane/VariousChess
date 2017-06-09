using WarChess.Domain.Checkers.Pieces;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers.Moves
{
    internal class CheckersSlidingMove : SlidingMove<CheckersGameState, CheckerCell, CheckerPiece>
    {
        public CheckersSlidingMove(Point2D step, GridPosition2D @from, GridPosition2D to) : base(step, @from, to)
        {
        }

        public override bool IsValid(CheckersGameState gameState)
            => base.IsValid(gameState) && !gameState.Field[To].ContainsPiece;

        protected override CheckersGameState Apply(CheckersGameState gameState)
            => gameState.MakeMove(new[] { From }, To, gameState.Field[From].Piece);
    }
}
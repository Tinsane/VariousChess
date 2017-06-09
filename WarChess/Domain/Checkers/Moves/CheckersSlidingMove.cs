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
        {
            if (!base.IsValid(gameState))
                return false;
            for (var position = (Point2D)From + Step; position != (Point2D)To; position = position + Step)
                if (gameState.Field[(GridPosition2D) position].ContainsPiece)
                    return false;
            return true;
        }

        protected override CheckersGameState Apply(CheckersGameState gameState)
            => gameState.MakeMove(new[] { From }, To, gameState.Field[From].Piece);
    }
}
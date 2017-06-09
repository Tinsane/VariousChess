using System.Collections.Generic;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers.Moves
{
    internal class OverJumpingMove : TransformingMove
    {
        public OverJumpingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        private GridPosition2D MiddlePosition => (GridPosition2D) ((Point2D) From + Step / 2);

        public override bool IsValid(CheckersGameState gameState)
        {
            if (!base.IsValid(gameState))
                return false;
            var middleCell = gameState.Field[MiddlePosition];
            return middleCell.ContainsPiece && middleCell.Piece.PlayerId != gameState.CurrentPlayerId;
        }

        protected override IEnumerable<GridPosition2D> ToRemove() => new[] {From, MiddlePosition};
    }
}
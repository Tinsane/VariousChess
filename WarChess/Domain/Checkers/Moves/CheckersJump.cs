using System.Collections.Generic;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers.Moves
{
    internal class CheckersJump : TransformingMove
    {
        public CheckersJump(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        public override bool IsValid(CheckersGameState gameState)
            => base.IsValid(gameState) && !gameState.Field[To].ContainsPiece;

        protected override IEnumerable<GridPosition2D> ToRemove() => new[] {From};
    }
}
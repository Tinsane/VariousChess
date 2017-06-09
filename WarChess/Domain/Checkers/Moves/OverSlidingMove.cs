using WarChess.Domain.Checkers.Pieces;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers.Moves
{
    internal class OverSlidingMove : DirectedMove<CheckersGameState, CheckerCell, CheckerPiece>
    {
        public OverSlidingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        private GridPosition2D EnemyPosition(CheckersGameState gameState)
        {
            for (var position = (Point2D) From + Step; position != (Point2D) To; position = position + Step)
            {
                var cell = gameState.Field[(GridPosition2D) position];
                if (cell.ContainsPiece && cell.Piece.PlayerId != gameState.CurrentPlayerId)
                    return (GridPosition2D) position;
            }
            return null;
        }

        public override bool IsValid(CheckersGameState gameState)
        {
            var enemyPosition = EnemyPosition(gameState);
            if (!base.IsValid(gameState) || ReferenceEquals(enemyPosition, null) || gameState.Field[To].ContainsPiece)
                return false;
            var enemyCell = gameState.Field[enemyPosition];
            if (!base.IsValid(gameState) || !enemyCell.ContainsPiece ||
                enemyCell.Piece.PlayerId == gameState.CurrentPlayerId)
                return false;
            for (var position = (Point2D) From + Step; position != (Point2D) To; position = position + Step)
            {
                var cell = gameState.Field[(GridPosition2D) position];
                if (cell.ContainsPiece && position != (Point2D) enemyPosition)
                    return false;
            }
            return true;
        }

        protected override CheckersGameState Apply(CheckersGameState gameState)
            => gameState.MakeMove(new[] {From, EnemyPosition(gameState)}, To, gameState.Field[From].Piece);
    }
}
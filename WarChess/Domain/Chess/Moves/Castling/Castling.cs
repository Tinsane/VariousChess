using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.Castling
{
    public abstract class Castling : KingMove
    {
        protected Castling(Point2D step, GridPosition2D rookPosition, GridPosition2D from,
            GridPosition2D to) : base(step, from, to)
        {
            RookPosition = rookPosition;
        }

        private GridPosition2D RookPosition { get; }

        public override bool IsValid(ChessGameState gameState)
        {
            var king = gameState.Field[From].Piece;
            if (!base.IsValid(gameState) || gameState.IsCheck() ||
                WasMovedVisitor.WasMoved(king))
                return false;
            var movementVector = Step / 2;
            var middlePosition = (GridPosition2D) ((Point2D) From + movementVector);
            if (gameState.IsCellAttacked(middlePosition, Utils.AnotherPlayerId(gameState.CurrentPlayerId)))
                return false;
            for (var position = (Point2D) middlePosition;
                position != (Point2D) RookPosition;
                position = position + movementVector)
                if (gameState.Field[(GridPosition2D) position].ContainsPiece)
                    return false;
            return true;
        }

        protected override ChessGameState Apply(ChessGameState gameState)
        {
            gameState = base.Apply(gameState);
            var middlePosition = (GridPosition2D) ((Point2D) From + Step / 2);
            return gameState.ChangeCurrentPlayer()
                .MovePiece(RookPosition, middlePosition, GetMovedVisitor.GetMoved);
        }
    }
}
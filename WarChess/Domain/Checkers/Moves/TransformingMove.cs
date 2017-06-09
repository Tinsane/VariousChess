using System.Collections.Generic;
using WarChess.Domain.Checkers.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers.Moves
{
    internal abstract class TransformingMove : Jump<CheckersGameState, CheckerCell, CheckerPiece>
    {
        protected TransformingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        public override bool IsValid(CheckersGameState gameState)
            => base.IsValid(gameState) && !gameState.Field[To].ContainsPiece;

        protected abstract IEnumerable<GridPosition2D> ToRemove();

        protected override CheckersGameState Apply(CheckersGameState gameState)
            => gameState.MakeMove(ToRemove(), To,
                gameState.CurrentPlayerId == Utils.WhitePlayerId && To.X == Utils.BoardSize - 1 ||
                gameState.CurrentPlayerId == Utils.BlackPlayerId && To.X == 0
                    ? new King(gameState.CurrentPlayerId)
                    : gameState.Field[From].Piece);
    }
}
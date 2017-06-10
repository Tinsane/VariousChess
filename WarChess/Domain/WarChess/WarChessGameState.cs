using System;
using System.Linq;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.Moves.PawnMoves;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.Chess.Pieces.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.WarChess
{
    public class WarChessGameState : ChessGameState
    {
        public WarChessGameState(BoundedGridField2D<ChessCell> field, int currentPlayerId,
            PawnDoubleJump previousPawnDoubleJump = null) : base(field, currentPlayerId, previousPawnDoubleJump)
        {
        }

        public bool CanPawnAttack()
        {
            foreach (var position in Field.Positions)
            {
                var cell = Field[position];
                if (!cell.ContainsPiece)
                    continue;
                var piece = cell.Piece;
                if (!PawnCheckVisitor.IsPawn(piece))
                    continue;
                if (new[] {new Point2D(1, 1), new Point2D(1, -1)}.Select(
                        direction => (GridPosition2D) ((Point2D) position +
                                                       (CurrentPlayerId == Utils.WhitePlayerId
                                                           ? direction
                                                           : -direction)))
                    .Where(target => Field.Contains(target))
                    .SelectMany(target => piece.GetPossibleMoves(position, target))
                    .Any(move => !ReferenceEquals(move.Make(this), null)))
                    return true;
            }
            return false;
        }

        public override ChessGameState MovePiece(GridPosition2D from, GridPosition2D to,
            Func<ChessPiece, ChessPiece> updatePiece)
            => new WarChessGameState(
                Field.GetWith(new ChessCell(), from).GetWith(new ChessCell(updatePiece(Field[from].Piece)), to),
                Utils.AnotherPlayerId(CurrentPlayerId));

        public override ChessGameState ChangeCurrentPlayer()
            => new WarChessGameState(Field, Utils.AnotherPlayerId(CurrentPlayerId));
    }
}
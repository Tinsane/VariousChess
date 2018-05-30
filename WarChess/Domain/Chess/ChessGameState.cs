using System;
using System.Linq;
using WarChess.Domain.Chess.Moves.PawnMoves;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.Chess.Pieces.Visitors;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    public class ChessGameState : ChessAlikeGameState<ChessCell, ChessPiece>
    {
        public ChessGameState(BoundedGridField2D<ChessCell> field, int currentPlayerId,
            PawnDoubleJump previousPawnDoubleJump = null) : base(field, currentPlayerId)
        {
            PreviousPawnDoubleJump = previousPawnDoubleJump;
        }

        public PawnDoubleJump PreviousPawnDoubleJump { get; }

        public bool IsCheck() => IsKingAttacked(CurrentPlayerId);

        public bool IsMate() => IsKingAttacked(CurrentPlayerId) && !CanCurrentPlayerMove();

        public bool IsStaleMate() => !IsKingAttacked(CurrentPlayerId) && !CanCurrentPlayerMove();

        private GridPosition2D FindKing(int playerId)
        {
            foreach (var position in Field.Positions)
            {
                var cell = Field[position];
                if (!cell.ContainsPiece)
                    continue;
                var piece = cell.Piece;
                if (KingCheckVisitor.IsKing(piece) && piece.PlayerId == playerId)
                    return position;
            }
            throw new InvalidOperationException();
        }

        public bool IsCellAttacked(GridPosition2D target, int attackerPlayerId)
        {
            foreach (var position in Field.Positions)
            {
                var cell = Field[position];
                if (!cell.ContainsPiece)
                    continue;
                var piece = cell.Piece;
                if (piece.PlayerId != attackerPlayerId)
                    continue;
                if (piece.GetPossibleMoves(position, target)
                    .Any(move => move.IsValid(attackerPlayerId == CurrentPlayerId ? this : ChangeCurrentPlayer())))
                    return true;
            }
            return false;
        }

        private bool IsKingAttacked(int playerId)
            => IsCellAttacked(FindKing(playerId), Utils.AnotherPlayerId(playerId));

        public bool CanCurrentPlayerMove()
        {
            foreach (var srcPosition in Field.Positions)
            {
                var srcCell = Field[srcPosition];
                if (!srcCell.ContainsPiece)
                    continue;
                var piece = srcCell.Piece;
                if (piece.PlayerId != CurrentPlayerId)
                    continue;
                if (Field.Positions
                    .SelectMany(dstPosition => piece.GetPossibleMoves(srcPosition, dstPosition))
                    .Any(move => !ReferenceEquals(move.Make(this), null)))
                    return true;
            }
            return false;
        }

        public override bool IsValid() => !IsKingAttacked(Utils.AnotherPlayerId(CurrentPlayerId));

        public virtual ChessGameState MovePiece(GridPosition2D from, GridPosition2D to,
            Func<ChessPiece, ChessPiece> updatePiece)
            => new ChessGameState(
                Field.GetWith(new ChessCell(), from).GetWith(new ChessCell(updatePiece(Field[from].Piece)), to),
                Utils.AnotherPlayerId(CurrentPlayerId));

        public virtual ChessGameState ChangeCurrentPlayer()
            => new ChessGameState(Field, Utils.AnotherPlayerId(CurrentPlayerId));
    }
}
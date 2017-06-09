using System;
using System.Linq;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    public class ChessGameState : ChessAlikeGameState<ChessCell, ChessPiece>
    {
        public ChessGameState(BoundedGridField2D<ChessCell> field, int currentPlayerId) : base(field, currentPlayerId)
        {
        }

        public bool IsCheck() => IsKingAttacked(CurrentPlayerId) && CanCurrentPlayerMove();

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

        private bool IsKingAttacked(int playerId)
        {
            foreach (var position in Field.Positions)
            {
                var cell = Field[position];
                if (!cell.ContainsPiece)
                    continue;
                var piece = cell.Piece;
                if (piece.PlayerId == playerId)
                    continue;
                if (piece.GetPossibleMoves(position, FindKing(playerId)).Any(move => move.IsValid(this)))
                    return true;
            }
            return false;
        }

        private bool CanCurrentPlayerMove()
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

        public override bool IsValid() => !IsKingAttacked((CurrentPlayerId + 1) % Utils.PlayersCount);

        public ChessGameState MovePiece(GridPosition2D from, GridPosition2D to,
            Func<ChessPiece, ChessPiece> updatePiece)
            => new ChessGameState(
                Field.GetWith(new ChessCell(), from).GetWith(new ChessCell(updatePiece(Field[from].Piece)), to),
                (CurrentPlayerId + 1) % Utils.PlayersCount);
    }
}
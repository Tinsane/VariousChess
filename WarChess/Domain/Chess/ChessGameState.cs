using System;
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

        private bool IsKingAttacked(int playerId) => throw new NotImplementedException();

        private bool CanCurrentPlayerMove() => throw new NotImplementedException();

        public override bool IsValid() => !IsKingAttacked(CurrentPlayerId ^ 1);

        public ChessGameState MovePiece(GridPosition2D from, GridPosition2D to,
            Func<ChessPiece, ChessPiece> updatePiece) => new ChessGameState(
            Field.GetWith(new ChessCell(), from).GetWith(new ChessCell(updatePiece(Field[from].Piece)), to),
            CurrentPlayerId ^ 1);
    }
}
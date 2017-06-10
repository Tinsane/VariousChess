using System;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.Moves.PawnMoves;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.WarChess
{
    public class WarChessGameState : ChessGameState
    {
        public WarChessGameState(BoundedGridField2D<ChessCell> field, int currentPlayerId,
            PawnDoubleJump previousPawnDoubleJump = null) : base(field, currentPlayerId, previousPawnDoubleJump)
        {
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
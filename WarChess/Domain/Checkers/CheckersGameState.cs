using System;
using WarChess.Domain.Checkers.Piece;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers
{
    internal class CheckersGameState : ChessAlikeGameState<CheckerCell, CheckerPiece>
    {
        public CheckersGameState(BoundedGridField2D<CheckerCell> field, int currentPlayerId) : base(field,
            currentPlayerId)
        {
        }

        public override bool IsValid() => throw new NotImplementedException();
    }
}
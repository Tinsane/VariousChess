using System;
using System.Collections.Generic;
using System.Linq;
using WarChess.Domain.Checkers.Pieces;
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

        public override bool IsValid() => true;
        public override bool CanCurrentPlayerMove() => throw new NotImplementedException();

        public CheckersGameState MakeMove(IEnumerable<GridPosition2D> toRemove, GridPosition2D finalCell,
            CheckerPiece finalPiece)
            => new CheckersGameState(
                toRemove.Aggregate(Field, (current, position) => current.GetWith(new CheckerCell(), position))
                    .GetWith(new CheckerCell(finalPiece), finalCell), Utils.AnotherPlayerId(CurrentPlayerId));
    }
}
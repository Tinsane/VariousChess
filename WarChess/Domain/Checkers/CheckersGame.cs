using System;
using System.Collections.Generic;
using WarChess.Domain.Checkers.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers
{
    internal class CheckersGame : ChessAlikeGame<CheckersGameState, CheckerCell, CheckerPiece>
    {
        public CheckersGame(CheckersGameState initialState) : base(initialState) { }

        public bool TryMakeMove(IEnumerable<GridPosition2D> cells) => throw new NotImplementedException();
    }
}
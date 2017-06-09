using System;
using System.Collections.Generic;
using WarChess.Domain.Checkers.Piece;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Checkers
{
    internal class CheckersGame : ChessAlikeGame<CheckersGameState, CheckerCell, CheckerPiece>
    {
        public CheckersGame(CheckersGameState initialState) : base(initialState) { }

        protected override IEnumerable<IChessAlikeMove<CheckersGameState, CheckerCell, CheckerPiece>> GetPossibleMoves(
            GridPosition2D from, GridPosition2D to) => throw new NotImplementedException();
    }
}
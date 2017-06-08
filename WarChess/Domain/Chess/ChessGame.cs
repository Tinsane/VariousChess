using System;
using System.Collections.Generic;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    public class ChessGame : ChessAlikeGame<ChessGameState, ChessCell, ChessPiece>
    {
        public ChessGame(ChessGameState initialState) : base(initialState) { }

        protected override IEnumerable<IChessAlikeMove<ChessGameState, ChessCell, ChessPiece>> GetPossibleMoves(
            GridPosition2D from, GridPosition2D to) => throw new NotImplementedException();
    }
}
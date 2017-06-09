using System;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class ChessGame : IChessGame
    {
        public IChessBoard<ChessPiece> Board { get; }
        public bool IsFinished { get; }
        public bool IsCheck { get; }
        public Color WhoseTurn { get; }
        public bool TryMakeMove(GridPosition2D from, GridPosition2D to) => throw new NotImplementedException();
    }
}
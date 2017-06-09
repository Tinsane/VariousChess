using System;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class MockChessGame : IChessGame
    {
        public MockChessGame() { Board = new MockBoard(); }

        public IChessBoard<ChessPiece> Board { get; }

        public bool IsFinished => false;
        public Color WhoseTurn => Color.White;
        public bool TryMakeMove(GridPosition2D from, GridPosition2D to) => throw new NotImplementedException();

        public bool IsCheck => false;
    }
}
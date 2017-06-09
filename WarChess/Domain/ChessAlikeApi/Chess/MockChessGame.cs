using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class MockChessGame : IChessGame
    {
        public MockChessGame()
        {
            Board = new MockBoard();
        }

        public IChessBoard<ChessPiece> Board { get; }

        public bool IsFinished => false;
        public Color WhoseTurn => Color.White;
        public bool TryMakeMove(GridPosition2D @from, GridPosition2D to) { throw new NotImplementedException(); }

        public bool IsCheck => false;
    }
}

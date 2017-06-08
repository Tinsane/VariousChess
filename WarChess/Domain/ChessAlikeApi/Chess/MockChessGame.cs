using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool TryMakeMove(ChessPosition @from, ChessPosition to)
        {
            throw new NotImplementedException();
        }

        public bool IsCheck => false;
    }
}

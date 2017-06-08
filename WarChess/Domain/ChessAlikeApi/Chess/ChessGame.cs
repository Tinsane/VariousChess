using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class Chess : IChessAlikeGame<ChessPiece>
    {
        public IChessBoard<ChessPiece> Board { get; }
        public bool IsFinished { get; }
        public bool IsCheck { get; }
        public Color WhoseTurn { get; }
        public bool TryMakeMove(ChessPosition @from, ChessPosition to)
        {
            throw new NotImplementedException();
        }
    }
}

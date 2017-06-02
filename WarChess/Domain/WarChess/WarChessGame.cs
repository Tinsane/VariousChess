using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.Domain.WarChess
{
    class WarChessGame : IWarChessGame
    {
        public Color WhoseMove => throw new NotImplementedException();

        public IField Field => throw new NotImplementedException();

        public WarChessAlert Alert => throw new NotImplementedException(); // возможно работает только в c#7

        public List<Position> GetPossibleMoves(Position from)
        {
            throw new NotImplementedException();
        }

        public bool TryMakeMove(Position from, Position to)
        {
            throw new NotImplementedException();
        }
    }
}

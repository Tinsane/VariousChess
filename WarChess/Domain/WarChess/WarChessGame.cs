using System;
using System.Collections.Generic;

namespace WarChess.Domain.WarChess
{
    public class WarChessGame : IWarChessGame
    {
        public Color WhoseMove => throw new NotImplementedException();

        public IField Field => throw new NotImplementedException();

        public WarChessAlert Alert => throw new NotImplementedException();

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
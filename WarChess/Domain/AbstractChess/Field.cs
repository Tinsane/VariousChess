using System;

namespace WarChess.Domain.AbstractChess
{
    internal class Field : IField
    {
        public IPiece this[Position position] => throw new NotImplementedException();

        public int ColumnsCount => throw new NotImplementedException();

        public int RowsCount => throw new NotImplementedException();
    }
}
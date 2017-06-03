using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.Domain.AbstractChess
{
    class Field : IField
    {
        public IPiece this[Position position]
        {
            get { throw new NotImplementedException(); }
        }

        public int ColumnsCount {
            get { throw new NotImplementedException(); }
        }
        public int RowsCount {
            get { throw new NotImplementedException(); }
        }
    }
}

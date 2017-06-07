using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.UserInterface
{
    public static class ChessUtils
    {
        public const int RowCount = 8;
        public const int ColumnCount = 8; // todo: use some global constants

        /// <param name="row">Indexing from 0</param>
        /// <param name="column">Indexing from 0</param>
        /// <returns></returns>
        public static ChessPosition GetPosition(int row, int column)
        {
            return new ChessPosition(('a' + column).ToString() + ('0' + (RowCount - row))); 
        }

        public static Bitmap[,] SelectAllBoard<TCell>(IChessBoard<TCell> board, ICellBitmapSelector<TCell> selector) // not here
        {
            var bitmaps = new Bitmap[RowCount, ColumnCount]; // todo: use constants
            for (int row = 0; row < RowCount; ++row)
            for (int column = 0; column < ColumnCount; ++column)
                bitmaps[row, column] = selector.SelectBitmap(board[GetPosition(row, column)]);
            return bitmaps;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.UserInterface
{
    public static class ChessUtils
    {
        /// <param name="row">Indexing from 0</param>
        /// <param name="column">Indexing from 0</param>
        /// <param name="rowCount">Total count of rows</param>
        /// <returns></returns>
        public static ChessPosition ToChessPosition(int row, int column, int rowCount) =>
            (((char)('a' + column)).ToString() + (char)('0' + (rowCount - row))).GetChessPosition();

        public static (int row, int column) FromChessPosition(ChessPosition position, int rowCount)
        {
            var chessNotation = position.GetChessNotation();
            return (rowCount - (chessNotation[1] - '0'), chessNotation[0] - 'a');
        }

        public static Bitmap[,] SelectAllBoard<TCell>(IChessBoard<TCell> board, ICellBitmapSelector<TCell> selector)
        {
            var bitmaps = new Bitmap[board.RowCount, board.ColumnCount];
            for (int row = 0; row < board.RowCount; ++row)
            for (int column = 0; column < board.ColumnCount; ++column)
                bitmaps[row, column] = selector.SelectBitmap(board[ToChessPosition(row, column, board.RowCount)]);
            return bitmaps;
        }
    }
}

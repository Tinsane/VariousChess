using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Domain;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Infrastructure;

namespace WarChess.UserInterface
{
    public class BoardControl : Control
    {
        public event Action<ChessPosition> CellClick;

        private readonly IBoardStyle boardStyle;
        private readonly int bitmapWidth;
        private readonly int bitmapHeight;

        private readonly DataGridView chessBoard;
        public BoardControl(IBoardStyle boardStyle, int bitmapWidth, int bitmapHeight)
        {
            this.boardStyle = boardStyle;
            this.bitmapWidth = bitmapWidth;
            this.bitmapHeight = bitmapHeight;
            chessBoard = new DataGridView();
            Controls.Add(chessBoard);

            chessBoard.CellClick += (sender, args) 
                => CellClick?.Invoke(ChessUtils.GetPosition(args.RowIndex, args.ColumnIndex, chessBoard.Rows.Count));
        }

        public void UpdateField(Bitmap[,] board)
        {
            chessBoard.Rows.Clear();
            var rowCount = board.GetLength(0);
            var columnCount = board.GetLength(1);
            for (int row = 0; row < rowCount; ++row)
            {
                var gridRow = new DataGridViewRow();
                for (int column = 0; column < columnCount; ++column)
                {
                    var cell = new DataGridViewImageCell {ValueType = typeof(Image)};
                    var cellColor = ((row + column) % 2 == 0) ? boardStyle.WhiteCellColor : boardStyle.BlackCellColor;
                    var cellBitmap = BitmapUtils.GetMonochromeBitmap(bitmapWidth, bitmapHeight, cellColor);
                    var pieceBitmap = board[row, column];
                    var resultBitmap = BitmapUtils.GetOverlayedBitmap(cellBitmap, pieceBitmap);
                    cell.Value = resultBitmap;
                    gridRow.Cells.Add(cell);
                }
                chessBoard.Rows.Add(gridRow);
            }
            Invalidate();
        }
    }
}

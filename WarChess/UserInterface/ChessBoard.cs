using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Domain;
using WarChess.Domain.Chess;
using WarChess.Domain.WarChess;
using WarChess.Infrastructure;
using Color = System.Drawing.Color;

namespace WarChess.UserInterface
{
    public class ChessBoard : Control
    {
        public const int RowCount = 8;
        public const int ColumnCount = 8;

        public event Action<ChessPosition> CellClick;

        private readonly IBoardStyle boardStyle;
        private readonly int bitmapWidth;
        private readonly int bitmapHeight;

        private readonly DataGridView chessBoard;
        public ChessBoard(IBoardStyle boardStyle, int bitmapWidth, int bitmapHeight)
        {
            this.boardStyle = boardStyle;
            this.bitmapWidth = bitmapWidth;
            this.bitmapHeight = bitmapHeight;
            chessBoard = new DataGridView();
            UpdateField(BitmapUtils.GetEmptyArray(RowCount, ColumnCount, bitmapWidth, bitmapHeight));
            Controls.Add(chessBoard);

            chessBoard.CellClick += (sender, args) 
                => CellClick?.Invoke(ChessUtils.GetPosition(args.RowIndex, args.ColumnIndex));
        }

        public void UpdateField(Bitmap[,] board)
        {
            chessBoard.Rows.Clear();
            for (int row = 0; row < RowCount; ++row)
            {
                var gridRow = new DataGridViewRow();
                for (int column = 0; column < ColumnCount; ++column)
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
        }
    }
}

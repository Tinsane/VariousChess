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
using Color = System.Drawing.Color;

namespace WarChess.UserInterface
{
    public class ChessBoard : Control
    {
        public const int RowCount = 8;
        public const int ColumnCount = 8;

        public event Func<ChessPosition> CellClick;

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
            UpdateField(GetEmptyBoard(bitmapWidth, bitmapHeight));
            Controls.Add(chessBoard);
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
                    var cellBitmap = GetMonochromeBitmap(bitmapWidth, bitmapHeight, cellColor);
                    var pieceBitmap = board[row, column];
                    var resultBitmap = GetOverlayedBitmap(cellBitmap, pieceBitmap);
                    cell.Value = resultBitmap;
                    gridRow.Cells.Add(cell);
                }
                chessBoard.Rows.Add(gridRow);
            }
            // TODO: probably need to reapaint something
        }
        
        /// <param name="row">Indexing from 0</param>
        /// <param name="column">Indexing from 0</param>
        /// <returns></returns>
        private static ChessPosition GetPosition(int row, int column)
        {
            return new ChessPosition(('a' + column).ToString() + ('0' + (RowCount - row)));
        }

        private static Bitmap GetMonochromeBitmap(int width, int height, Color color)
        {
            var bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (SolidBrush brush = new SolidBrush(color))
                graphics.FillRectangle(brush, 0, 0, width, height);
            return bitmap;
        }

        private static Bitmap GetColoredBitmap(Bitmap bitmap, Color color)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; ++x)
            for (int y = 0; y < bitmap.Height; ++y)
            {
                var curColor = bitmap.GetPixel(x, y);
                var newColor = Color.FromArgb(curColor.A, color.R, color.G, color.B);
                newBitmap.SetPixel(x, y, newColor);
            }
            return newBitmap;
        }

        private static Bitmap GetOverlayedBitmap(Bitmap under, Bitmap above)
        {
            int width = Math.Max(under.Width, above.Width);
            int height = Math.Max(under.Height, above.Height);
            var finalBitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(finalBitmap))
            {
                graphics.DrawImage(under, 0, 0);
                graphics.DrawImage(above, 0, 0);
            }
            return finalBitmap;
        }

        private static Bitmap[,] GetEmptyBoard(int bitmapWidth, int bitmapHeight)
        {
            var board = new Bitmap[RowCount, ColumnCount];
            for (int row = 0; row < RowCount; ++row)
            for (int column = 0; column < ColumnCount; ++column)
                board[row, column] = GetMonochromeBitmap(bitmapWidth, bitmapHeight, Color.FromArgb(0));
            return board;
        }
    }
}

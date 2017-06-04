using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Domain.AbstractChess;
using Color = System.Drawing.Color;

namespace WarChess.UserInterface
{
    public class ChessField : Control
    {
        public static int RowCount = 8;
        public static int ColumnCount = 8;

        private readonly IFieldStyle style;
        private readonly DataGridView dataGrid;
        public ChessField(IFieldStyle style, IPieceBitmapSelector bitmapSelector, IField field)
        {
            this.style = style;
            dataGrid = new DataGridView();
            Controls.Add(dataGrid);
            for (int row = 0; row < RowCount; ++row)
            {
                var gridRow = new DataGridViewRow();
                for (int column = 0; column < ColumnCount; ++column)
                {
                    var cell = new DataGridViewImageCell();
                    cell.ValueType = typeof(Image);
                    var piece = field[GetPosition(row, column)];
                    var cellColor = ((row + column) % 2 == 0) ? style.WhiteCellColor : style.BlackCellColor;
                    var fieldCellBitmap = GetMonochromeBitmap(bitmapSelector.BitmapWidth, 
                        bitmapSelector.BitmapHeight, cellColor);
                    // TODO: finish
                }
            }
        }
        
        /// <param name="row">Indexing from 0</param>
        /// <param name="column">Indexing from 0</param>
        /// <returns></returns>
        private Position GetPosition(int row, int column)
        {
            return new Position(('a' + column).ToString() + ('0' + (RowCount - row)));
        }

        private Bitmap GetMonochromeBitmap(int width, int height, Color color)
        {
            var bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (SolidBrush brush = new SolidBrush(color))
                graphics.FillRectangle(brush, 0, 0, width, height);
            return bitmap;
        }

        private Bitmap ColorBitmap(Bitmap bitmap, Color color)
        {
            return null;
        }
    }
}

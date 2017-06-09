using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Domain;
using WarChess.Domain.Chess;
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
        private Bitmap[,] boardBitmaps;

        private readonly TableLayoutPanel chessBoard;
        public BoardControl(IBoardStyle boardStyle, int bitmapWidth, int bitmapHeight)
        {
            this.boardStyle = boardStyle;
            this.bitmapWidth = bitmapWidth;
            this.bitmapHeight = bitmapHeight;
            MouseClick += (sender, args) =>  CellClick?.Invoke(
                ChessUtils.GetPosition(args.Y / bitmapHeight,
                                       args.X / bitmapWidth,
                                       boardBitmaps.GetLength(0)));
        }

        public void UpdateField(Bitmap[,] board)
        {
            MinimumSize = new Size(bitmapWidth * board.GetLength(0), bitmapHeight * board.GetLength(1));
            boardBitmaps = new Bitmap[board.GetLength(0), board.GetLength(1)];
            for (int row = 0; row < board.GetLength(0); ++row)
            {
                for (int column = 0; column < board.GetLength(1); ++column)
                {
                    var cellColor = ((row + column) % 2 == 0) ? boardStyle.WhiteCellColor : boardStyle.BlackCellColor;
                    var cellBitmap = BitmapUtils.GetMonochromeBitmap(bitmapWidth, bitmapHeight, cellColor);
                    var pieceBitmap = board[row, column];
                    var resultBitmap = BitmapUtils.GetOverlayedBitmap(cellBitmap, pieceBitmap);
                    boardBitmaps[row, column] = resultBitmap;
                }
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int row = 0; row < boardBitmaps.GetLength(0); ++row)
            for (int column = 0; column < boardBitmaps.GetLength(1); ++column)
            {
                e.Graphics.DrawImage(boardBitmaps[row, column], row * bitmapHeight, column * bitmapWidth);
            }
        }
    }
}

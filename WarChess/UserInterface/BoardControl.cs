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
    public class BoardControl : AbstractBoardControl
    {
        public override event Action<ChessPosition> CellClick;

        private readonly IBoardStyle boardStyle;
        private readonly Size cellSize;
        private Bitmap[,] boardCells;

        public BoardControl(IBoardStyle boardStyle, Size cellSize)
        {
            this.boardStyle = boardStyle;
            this.cellSize = cellSize;
            MouseClick += (sender, args) =>  CellClick?.Invoke(
                ChessUtils.ToChessPosition(args.Y / cellSize.Height,
                                       args.X / cellSize.Width,
                                       boardCells.GetLength(0)));
        }

        public override void UpdateField(Bitmap[,] board)
        {
            MinimumSize = new Size(cellSize.Width * board.GetLength(0), cellSize.Height * board.GetLength(1));
            boardCells = new Bitmap[board.GetLength(0), board.GetLength(1)];
            for (int row = 0; row < board.GetLength(0); ++row)
            {
                for (int column = 0; column < board.GetLength(1); ++column)
                {
                    var cellColor = ((row + column) % 2 == 0) ? boardStyle.WhiteCellColor : boardStyle.BlackCellColor;
                    var cellBitmap = BitmapUtils.GetMonochromeBitmap(cellSize.Width, cellSize.Height, cellColor);
                    var pieceBitmap = board[row, column];
                    var resultBitmap = BitmapUtils.GetOverlayedBitmap(cellBitmap, pieceBitmap);
                    boardCells[row, column] = resultBitmap;
                }
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int row = 0; row < boardCells.GetLength(0); ++row)
            for (int column = 0; column < boardCells.GetLength(1); ++column)
            {
                e.Graphics.DrawImage(boardCells[row, column], row * cellSize.Height, column * cellSize.Width);
            }
        }
    }
}

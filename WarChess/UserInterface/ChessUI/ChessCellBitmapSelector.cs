using System;
using System.Drawing;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Infrastructure;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessCellBitmapSelector : ICellBitmapSelector<ChessPiece>
    {
        private readonly IChessStyle style;

        public ChessCellBitmapSelector(IChessStyle style)
        {
            this.style = style;
        }

        public int BitmapWidth => style.BitmapWidth;
        public int BitmapHeight => style.BitmapHeight;
        public Bitmap SelectBitmap(ChessPiece piece)
        {
            if (piece == null)
                return BitmapUtils.GetMonochromeBitmap(BitmapWidth, BitmapHeight, Color.FromArgb(0));
            throw new NotImplementedException("Зачем-то понадобилось отображение фигур");
        }
    }
}

using System;
using System.Drawing;
using WarChess.Domain.ChessAlikeApi.Chess;

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
            throw new NotImplementedException();
        }
    }
}

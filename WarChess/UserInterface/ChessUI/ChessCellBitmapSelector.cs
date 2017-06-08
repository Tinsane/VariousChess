using System;
using System.Drawing;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessCellBitmapSelector : ICellBitmapSelector<ChessPiece>
    {
        public int BitmapWidth { get; }
        public int BitmapHeight { get; }
        public Bitmap SelectBitmap(ChessPiece piece)
        {
            throw new NotImplementedException();
        }
    }
}

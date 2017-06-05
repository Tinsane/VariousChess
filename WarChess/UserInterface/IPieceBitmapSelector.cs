using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain;
using WarChess.Domain.Chess;
using WarChess.Domain.WarChess;

namespace WarChess.UserInterface
{
    public interface IPieceBitmapSelector
    {
        // All the bitmaps should have size (width, height)
        int BitmapWidth { get; }
        int BitmapHeight { get; }
        Bitmap SelectBitmap(IChessPiece piece);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.AbstractChess;
using WarChess.Domain.WarChess;

namespace WarChess.UserInterface.WarChess
{
    public class WarChessPieceBitmapSelector : IPieceBitmapSelector
    {
        private IStandardChessStyle style;
        public WarChessPieceBitmapSelector(IStandardChessStyle style, IWarChessGame game)
        { // if piece is visible - select bitmap, othervise - transparent bitmap
            this.style = style;
        }

        public Bitmap SelectBitmap(IPiece piece)
        {
            throw new NotImplementedException();
        }

    }
}

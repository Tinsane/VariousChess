using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.UserInterface
{
    class ChessStyleFromDir : IChessStyle
    {
        public int BitmapWidth => 30;

        public int BitmapHeight => 30;

        public Color BlackPieceColor => Color.Black;

        public Color WhitePieceColor => Color.White;

        public Bitmap Pawn => bitmaps["pawn"];

        public Bitmap Bishop => bitmaps["bishop"];

        public Bitmap Knight => bitmaps["knight"];

        public Bitmap Rook => bitmaps["rook"];

        public Bitmap Queen => bitmaps["queen"];

        public Bitmap King => bitmaps["king"];

        public ChessStyleFromDir(string dirName)
        {
            var actualDirName = @"..\..\UserInterface\" + dirName;
            bitmaps = new Dictionary<string, Bitmap>();
            foreach (var figureName in new[] { "pawn", "bishop", "knight", "rook", "queen", "king" })
                bitmaps[figureName] = new Bitmap(actualDirName + @"\" + figureName + ".png");
        }

        private Dictionary<string, Bitmap> bitmaps;
    }
}

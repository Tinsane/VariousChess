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
        public int BitmapWidth => 75;

        public int BitmapHeight => 75;

        public Bitmap BlackPawn => bitmaps["black_pawn"];

        public Bitmap BlackBishop => bitmaps["black_bishop"];

        public Bitmap BlackKnight => bitmaps["black_knight"];

        public Bitmap BlackRook => bitmaps["black_rook"];

        public Bitmap BlackQueen => bitmaps["black_queen"];

        public Bitmap BlackKing => bitmaps["black_king"];

        public Bitmap WhitePawn => bitmaps["white_pawn"];

        public Bitmap WhiteBishop => bitmaps["white_bishop"];

        public Bitmap WhiteKnight => bitmaps["white_knight"];

        public Bitmap WhiteRook => bitmaps["white_rook"];

        public Bitmap WhiteQueen => bitmaps["white_queen"];

        public Bitmap WhiteKing => bitmaps["white_king"];

        public ChessStyleFromDir(string dirName)
        {
            var actualDirName = @"..\..\UserInterface\" + dirName;
            bitmaps = new Dictionary<string, Bitmap>();
            foreach (var figureName in new[] { "pawn", "bishop", "knight", "rook", "queen", "king" })
                foreach (var color in new[] { "white", "black"})
                    bitmaps[color + "_" + figureName] = new Bitmap(actualDirName + @"\" + color + "_" + figureName + ".png");
        }

        private Dictionary<string, Bitmap> bitmaps;
    }
}

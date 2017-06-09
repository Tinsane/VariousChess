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
        private string dirName;

        public int BitmapWidth => 30;

        public int BitmapHeight => 30;

        public Color BlackPieceColor => Color.Black;

        public Color WhitePieceColor => Color.White;

        public Bitmap Pawn => new Bitmap(dirName + @"/pawn.png");

        public Bitmap Bishop => new Bitmap(dirName + @"/bishop.png");

        public Bitmap Knight => new Bitmap(dirName + @"/knight.png");

        public Bitmap Rook => new Bitmap(dirName + @"/rook.png");

        public Bitmap Queen => new Bitmap(dirName + @"/queen.png");

        public Bitmap King => new Bitmap(dirName + @"/king.png");

        public ChessStyleFromDir(string dirName)
        {
            this.dirName = @"..\..\UserInterface\" + dirName;
        }
    }
}

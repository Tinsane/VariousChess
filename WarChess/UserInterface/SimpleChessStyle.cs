using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.UserInterface
{
    class SimpleChessStyle : ChessStyleFromDir
    {
        public override int BitmapWidth => 60;

        public override int BitmapHeight => 60;

        public SimpleChessStyle() : base("SimpleChessStylePics")
        {
        }
    }
}

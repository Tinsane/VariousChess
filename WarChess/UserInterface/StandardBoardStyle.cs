using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.UserInterface
{
    public class StandardBoardStyle : IBoardStyle
    {
        public Color BlackCellColor => Color.DarkSlateGray;
        public Color WhiteCellColor => Color.LightYellow;
    }
}

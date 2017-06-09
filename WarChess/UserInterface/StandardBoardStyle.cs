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
        public Color BlackCellColor => Color.FromArgb(255, 255, 206, 158);
        public Color WhiteCellColor => Color.FromArgb(255, 209, 139, 71);
    }
}

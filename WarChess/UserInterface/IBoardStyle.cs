﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.UserInterface
{
    public interface IBoardStyle
    {
        Color BlackCellColor { get; }
        Color WhiteCellColor { get; }
    }
}

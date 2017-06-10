using System;
using System.Drawing;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi;
using WarChess.UserInterface.ChessUI;

namespace WarChess.UserInterface.WarChessUI
{
    public class WarChessCellBitmapSelector : ChessCellBitmapSelector
    {
        public WarChessCellBitmapSelector(IChessStyle style) : base(style)
        {
        }
    }
}

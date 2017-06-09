using System;
using System.Drawing;
using System.Windows.Forms;
using WarChess.Domain.Chess;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.UserInterface
{
    public abstract class AbstractBoardControl : Control
    {
        public abstract event Action<ChessPosition> CellClick;
        public abstract void UpdateField(Bitmap[,] board);
    }
}
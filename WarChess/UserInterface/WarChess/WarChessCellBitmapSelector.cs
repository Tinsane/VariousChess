using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Application;
using WarChess.Domain;
using WarChess.Domain.AbstractGame;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.WarChess;
using WarChess.Domain.WarChess;

namespace WarChess.UserInterface.WarChess
{
    public class WarChessCellBitmapSelector : ICellBitmapSelector<IChessPiece>
    {   // PROBABLY IT'S ENOUGH TO USE USUAL CHESS BITMAP SELECTOR
        // INSTEAD OF WAR CHESS APP WE CAN USE IChessAlikeApp
        private readonly IChessStyle style;

        private readonly WarChessApp app;

        // здесь нужен не IWarChessGame, а класс с уровня application
        public WarChessCellBitmapSelector(IChessStyle style, WarChessApp app)
        {
            // if piece is visible - select bitmap, othervise - transparent bitmap
            this.style = style;
            this.app = app;
        }

        public int BitmapWidth => style.BitmapWidth;
        public int BitmapHeight => style.BitmapHeight;

        public Bitmap SelectBitmap(IChessPiece piece)
        {
            // Тут switch по piece.Name и сопоставление текстурок из style
            throw new NotImplementedException();
        }
    }
}

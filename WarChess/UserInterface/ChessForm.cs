using System;
using System.Windows.Forms;
using WarChess.Application;

namespace WarChess.UserInterface
{
    public class ChessForm<TGame, TCell> : Form
        // where TGame : IChessAlike<TCell>
    {
        private readonly IChessAlikeApp<TGame> app;
        private readonly IBoardStyle boardStyle;
        private readonly ChessBoard board;

        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Поля для отображения уже срубленных фигур. (опционально)
         * 3. Историю. (опционально)
         * 4. Сообщения игрокам. (опционально)
         */
        public ChessForm(IChessAlikeApp<TGame> app, IBoardStyle boardStyle, 
            ICellBitmapSelector<TCell> bitmapSelector, IMessageSelector<TCell> messageSelector)
        {
            this.app = app;
            board = new ChessBoard(boardStyle, bitmapSelector.BitmapWidth, bitmapSelector.BitmapHeight);
            board.CellClick += app.ClickAt;
            app.StateChanged += Invalidate;
            // need some layout
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //board.UpdateField(ChessUtils.SelectAllBoard(app.Game.Board, bitmapSelector));
            // TODO: update message, history and all that stuff
            base.OnPaint(e);
            throw new NotImplementedException();
        }
    }
}

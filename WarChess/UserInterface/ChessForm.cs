using System;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.UserInterface
{
    public class ChessForm<TGame, TCell> : Form
        where TGame : IChessBoardGame<TCell>
    {
        private readonly IChessBoardApp<TGame, TCell> app;
        private readonly ICellBitmapSelector<TCell> bitmapSelector;
        private readonly IMessageSelector<TGame> messageSelector;
        private readonly ChessBoardControl boardControl;

        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Историю.
         * 3. Сообщения игрокам.
         */
        public ChessForm(IChessBoardApp<TGame, TCell> app, IBoardStyle boardStyle, 
            ICellBitmapSelector<TCell> bitmapSelector, IMessageSelector<TGame> messageSelector)
        {
            this.app = app;
            this.bitmapSelector = bitmapSelector;
            this.messageSelector = messageSelector;
            boardControl = new ChessBoardControl(boardStyle, bitmapSelector.BitmapWidth, bitmapSelector.BitmapHeight);
            boardControl.CellClick += app.ClickAt;
            app.StateChanged += Invalidate;
            // need some layout
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            boardControl.UpdateField(ChessUtils.SelectAllBoard(app.Game.Board, bitmapSelector));
            // TODO: update message, history and all that stuff
            base.OnPaint(e);
            throw new NotImplementedException();
        }
    }
}

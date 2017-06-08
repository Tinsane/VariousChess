using System;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessForm : Form
    {
        private readonly ChessApp app;
        private readonly ICellBitmapSelector<ChessPiece> bitmapSelector;
        private readonly IMessageSelector<ChessGame> messageSelector;
        private readonly BoardControl board;

        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Историю.
         * 3. Сообщения игрокам.
         */
        public ChessForm(ChessApp app, IBoardStyle boardStyle, 
            ICellBitmapSelector<ChessPiece> bitmapSelector, IMessageSelector<ChessGame> messageSelector)
        {
            this.app = app;
            this.bitmapSelector = bitmapSelector;
            this.messageSelector = messageSelector;
            board = new BoardControl(boardStyle, bitmapSelector.BitmapWidth, bitmapSelector.BitmapHeight);
            board.CellClick += app.ClickAt;
            app.StateChanged += Invalidate;
            // need some layout
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            board.UpdateField(ChessUtils.SelectAllBoard(app.Game.Board, bitmapSelector));
            // TODO: update message, history and all that stuff
            base.OnPaint(e);
            throw new NotImplementedException();
        }
    }
}

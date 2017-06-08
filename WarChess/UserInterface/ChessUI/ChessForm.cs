using System;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessForm : Form, IGameForm
    {
        private readonly ChessApp app;
        private readonly ICellBitmapSelector<ChessPiece> bitmapSelector;
        private readonly IMessageSelector<IChessGame> messageSelector;
        private readonly BoardControl board; // maybe better to create interface too

        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Историю.
         * 3. Сообщения игрокам.
         */
        public ChessForm(ChessApp app, IBoardStyle boardStyle, 
            ICellBitmapSelector<ChessPiece> bitmapSelector, IMessageSelector<IChessGame> messageSelector)
        {
            this.app = app;
            this.bitmapSelector = bitmapSelector;
            this.messageSelector = messageSelector;
            board = new BoardControl(boardStyle, bitmapSelector.BitmapWidth, bitmapSelector.BitmapHeight);
            board.CellClick += app.ClickAt;
            app.StateChanged += UpdateForm;
            Controls.Add(board);
        }

        public void UpdateForm()
        {
            board.UpdateField(ChessUtils.SelectAllBoard(app.Game.Board, bitmapSelector));
            // update history, messages or maybe something else
            Invalidate();
        }

        public string GameName => "Шахматы";
        public void Run(Form previous) => previous.SwitchTo(this);
    }
}

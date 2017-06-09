using System;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Infrastructure;
using WarChess.UserInterface.FocusBitmapSupplier;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessForm : Form, IGameForm
    {
        private readonly ChessApp app;
        private readonly ICellBitmapSelector<ChessPiece> bitmapSelector;
        private readonly IMessageSelector<IChessGame> messageSelector;
        private readonly AbstractBoardControl board;
        private readonly IFocusBitmapSupplier focusBitmapSupplier;

        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Историю.
         * 3. Сообщения игрокам.
         */
        public ChessForm(ChessApp app, AbstractBoardControl board, IFocusBitmapSupplier focusBitmapSupplier,
            ICellBitmapSelector<ChessPiece> bitmapSelector, IMessageSelector<IChessGame> messageSelector)
        {
            this.app = app;
            this.bitmapSelector = bitmapSelector;
            this.messageSelector = messageSelector;
            this.board = board;
            this.focusBitmapSupplier = focusBitmapSupplier;
            board.CellClick += app.ClickAt;
            app.StateChanged += UpdateForm;
            Controls.Add(board);
            UpdateForm();
        }

        public void UpdateForm()
        {
            var piecesBitmaps = ChessUtils.SelectAllBoard(app.Game.Board, bitmapSelector);
            if (app.SelectedPiecePosition != null)
            {
                (int row, int column) = ChessUtils.FromChessPosition(
                    app.SelectedPiecePosition, app.Game.Board.RowCount);
                var pieceBitmap = piecesBitmaps[row, column];
                var focusBitmap = focusBitmapSupplier.GetFocusBitmap(pieceBitmap.Width, pieceBitmap.Height);
                piecesBitmaps[row, column] = BitmapUtils.GetOverlayedBitmap(focusBitmap, pieceBitmap);
            }
            board.UpdateField(piecesBitmaps);
            // update history, messages or maybe something else
            Invalidate();
        }
        public string GameName => "Шахматы";
        public void Run(Form previous) => previous.SwitchTo(this);
    }
}

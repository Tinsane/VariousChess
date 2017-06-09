using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Infrastructure;
using WarChess.UserInterface.FocusBitmapSupplier;

namespace WarChess.UserInterface
{
    public class ChessAlikeGameControl<TGame, TCell> : Control
        where TGame : IChessAlikeGame<TCell>
        where TCell : IChessAlikePiece
    {
        private readonly ChessAlikeApp<TGame, TCell> app;
        private readonly ICellBitmapSelector<TCell> bitmapSelector;
        private readonly IMessageSelector<TGame> messageSelector;
        private readonly AbstractBoardControl board;
        private readonly IFocusBitmapSupplier focusBitmapSupplier;

        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Историю.
         * 3. Сообщения игрокам.
         */
        public ChessAlikeGameControl(ChessAlikeApp<TGame, TCell> app, AbstractBoardControl board,
            IFocusBitmapSupplier focusBitmapSupplier, ICellBitmapSelector<TCell> bitmapSelector, 
            IMessageSelector<TGame> messageSelector)
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
            MinimumSize = board.MinimumSize;
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
            // update messages
            Invalidate();
        }
    }
}

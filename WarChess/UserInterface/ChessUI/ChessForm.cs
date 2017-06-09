using System;
using System.Drawing;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Infrastructure;
using WarChess.UserInterface.FocusBitmapSupplier;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessForm : Form, IGameForm
    {
        private readonly ChessAlikeApp<IChessGame, ChessPiece> app;
        private readonly ChessAlikeGameControl<IChessGame, ChessPiece> gameControl;
        
        public ChessForm(ChessAlikeApp<IChessGame, ChessPiece> app, AbstractBoardControl board, IFocusBitmapSupplier focusBitmapSupplier,
            ICellBitmapSelector<ChessPiece> bitmapSelector, IMessageSelector<IChessGame> messageSelector)
        {
            this.app = app;
            gameControl = new ChessAlikeGameControl<IChessGame, ChessPiece>(
                app, board, focusBitmapSupplier, bitmapSelector, messageSelector);
            Controls.Add(gameControl);
            AutoSize = true;
            UpdateForm();
        }

        public void UpdateForm()
        {
            gameControl.UpdateForm();
            Invalidate();
        } 

        public string GameName => "Шахматы";
        public void Run(Form previous) => previous.SwitchTo(this);
    }
}

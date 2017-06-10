using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Domain.WarChess;
using WarChess.UserInterface.FocusBitmapSupplier;

namespace WarChess.UserInterface.WarChessUI
{
    public class WarChessForm : Form, IGameForm
    {
        public const string EndTurn = "Завершить ход";
        public const string StartTurn = "Начать ход";

        private readonly WarChessApp app;
        private readonly ChessAlikeGameControl<IWarChessGame, ChessPiece> gameControl;
        private Button switchTurnButton;

        public WarChessForm(WarChessApp app, AbstractBoardControl board, IFocusBitmapSupplier focusBitmapSupplier,
            ICellBitmapSelector<ChessPiece> bitmapSelector, IMessageSelector<IWarChessGame> messageSelector)
        {
            this.app = app;
            gameControl = new ChessAlikeGameControl<IWarChessGame, ChessPiece>(
                app, board, focusBitmapSupplier, bitmapSelector, messageSelector);
            Controls.Add(gameControl);
            switchTurnButton = new Button();
            switchTurnButton.Click += (sender, args) => app.GameIsVisible = !app.GameIsVisible;
            switchTurnButton.Anchor = AnchorStyles.Bottom;
            switchTurnButton.Dock = DockStyle.Bottom;
            Controls.Add(switchTurnButton);
            AutoSize = true;
            UpdateForm();
        }

        public void UpdateForm()
        {
            if (app.GameIsVisible)
            {
                gameControl.Show();
                switchTurnButton.Text = EndTurn;
            }
            else
            {
                gameControl.Hide();
                switchTurnButton.Text = StartTurn;
            }
            gameControl.UpdateForm();
            Invalidate();
        }
        public string GameName => "Военные шахматы";
        public void Run(Form previous) => previous.SwitchTo(this);
    }
}

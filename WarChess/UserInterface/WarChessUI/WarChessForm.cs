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

        private readonly WarChessApp app;
        private readonly ChessAlikeGameControl<IWarChessGame, ChessPiece> gameControl;
        private Button switchTurnButton;
        private ILanguagePack<WarChessGame> languagePack;

        public WarChessForm(WarChessApp app, AbstractBoardControl board, IFocusBitmapSupplier focusBitmapSupplier,
            ICellBitmapSelector<ChessPiece> bitmapSelector, IMessageSelector<IWarChessGame> messageSelector,
            IWarChessLanguagePack languagePack)
        {
            this.app = app;
            this.languagePack = languagePack;
            gameControl = new ChessAlikeGameControl<IWarChessGame, ChessPiece>(
                app, board, focusBitmapSupplier, bitmapSelector, messageSelector);
            Controls.Add(gameControl);
            switchTurnButton = new Button
            {
                Text = languagePack.StartTurn,
                Anchor = AnchorStyles.Bottom,
                Dock = DockStyle.Bottom
            };
            app.StateChanged += UpdateForm;
            switchTurnButton.Click += (sender, args) => app.GameIsVisible = true;
            Controls.Add(switchTurnButton);
            AutoSize = true;
            UpdateForm();
        }

        public void UpdateForm()
        {
            if (app.GameIsVisible)
            {
                gameControl.Show();
                switchTurnButton.Hide();
            }
            else
            {
                gameControl.Hide();
                switchTurnButton.Show();
            }
            gameControl.UpdateForm();
            Invalidate();
        }

        public string GameName => languagePack.GameName;
        public void Run(Form previous) => previous.SwitchTo(this);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.WarChess;

namespace WarChess.Application
{
    public class WarChessApp : ChessAlikeApp<IWarChessGame, ChessPiece>
    {
        private bool gameIsVisible;
        private bool currentTurnStarted = true;

        public bool GameIsVisible
        {
            get => gameIsVisible;
            set
            {
                if (!currentTurnStarted && !gameIsVisible && value)
                {
                    currentTurnStarted = true;
                    gameIsVisible = true;
                    StateChangedInvoker();
                }
            }
        }

        public WarChessApp(IWarChessGame game) : base(game)
        {
            gameIsVisible = true;
        }

        public override void ClickAt(ChessPosition position)
        {
            if (SelectOrUnselect(position))
                return;
            if (SelectedPiecePosition == null) return;
            if (game.TryMakeMove(SelectedPiecePosition, position))
            {
                SelectedPiecePosition = null;
                gameIsVisible = false;
                currentTurnStarted = false;
                StateChangedInvoker();
            }
            else
                Select(null);
        }
    }
}

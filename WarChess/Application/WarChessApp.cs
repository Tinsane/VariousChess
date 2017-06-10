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
        private bool currentTurnFinished = false;

        public bool GameIsVisible
        {
            get => gameIsVisible;
            set
            {
                if ((currentTurnFinished && !value) || value)
                {
                    if (!value)
                        currentTurnFinished = false;
                    gameIsVisible = value;
                    StateChangedInvoker();
                }
            }
        }

        public WarChessApp(IWarChessGame game) : base(game)
        {
            gameIsVisible = true;
            TurnMade += () => currentTurnFinished = true;
        }
    }
}

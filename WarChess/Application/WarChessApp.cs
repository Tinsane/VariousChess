using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.WarChess;

namespace WarChess.Application
{
    public class WarChessApp : ChessAlikeApp<IWarChessGame>
    {
        public ChessPosition SelectedPiecePosition { get; set; }
        public override event Action StateChanged;

        public WarChessApp(IWarChessGame game) : base(8, 8, game) // TODO: get constants somewhere
            // TODO: maybe we should create some class with such kind of constants
        {
        }

        private void Select(ChessPosition position)
        {
            SelectedPiecePosition = position;
            StateChanged?.Invoke();
        }

        public override void ClickAt(ChessPosition position)
        {
            if (SelectedPiecePosition == position)
                Select(null);
            var piece = game.Board[position];
            if (piece?.Color == game.WhoseMove)
                Select(position);
            if (SelectedPiecePosition != null && piece != null)
            {
                if (game.TryMakeMove(SelectedPiecePosition, position))
                {
                    // maybe increment move number, add something to history or something else
                    SelectedPiecePosition = null;
                    StateChanged?.Invoke();
                }
                else
                    Select(null);
            }
        }
    }
}

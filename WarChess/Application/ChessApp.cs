using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.Application
{
    public class ChessApp : ChessBoardApp<IChessGame, IChessAlikePiece>, 
        IChessAlikeApp<IChessGame, IChessAlikePiece>
    {
        public ChessPosition SelectedPiecePosition { get; set; }
        public override event Action StateChanged;

        public ChessApp(IChessGame game) : base(game)
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
            {
                Select(null);
                return;
            }
            var piece = game.Board[position];
            if (SelectedPiecePosition == null && piece?.Color == game.WhoseTurn)
            {
                Select(position);
                return;
            }
            if (SelectedPiecePosition != null)
            {
                if (game.TryMakeMove(SelectedPiecePosition, position))
                {
                    // maybe increment move number or something else
                    SelectedPiecePosition = null;
                    StateChanged?.Invoke();
                }
                else
                    Select(null);
            }
        }
    }
}

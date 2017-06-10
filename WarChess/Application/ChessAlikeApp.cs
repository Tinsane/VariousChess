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
    public class ChessAlikeApp<TGame, TCell> : ChessBoardApp<TGame, TCell>, 
        IChessAlikeApp<TGame, TCell>
        where TGame : IChessAlikeGame<TCell>
        where TCell : IChessAlikePiece
    {
        public ChessPosition SelectedPiecePosition { get; set; }
        public override event Action StateChanged;
        protected void StateChangedInvoker() => StateChanged?.Invoke();

        public ChessAlikeApp(TGame game) : base(game)
        {
        }

        protected bool SelectOrUnselect(ChessPosition position)
        {
            if (game.IsFinished)
                return true;
            if (SelectedPiecePosition == position)
            {
                Select(null);
                return true;
            }
            if (SelectedPiecePosition == null)
            {
                Select(position);
                return true;
            }
            return false;
        }

        protected void Select(ChessPosition position)
        {
            SelectedPiecePosition = position;
            StateChanged?.Invoke();
        }

        public override void ClickAt(ChessPosition position)
        {
            if (SelectOrUnselect(position))
                return;
            if (SelectedPiecePosition == null) return;
            if (game.TryMakeMove(SelectedPiecePosition, position))
            {
                SelectedPiecePosition = null;
                StateChanged?.Invoke();
            }
            else
                Select(null);
        }
    }
}

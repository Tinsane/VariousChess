using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Application
{
    public abstract class ChessBoardApp<TGame, TCell> : IChessBoardApp<TGame, TCell>
        where TGame : IChessBoardGame<TCell>
    {
        protected readonly TGame game;

        public TGame Game => game;

        protected ChessBoardApp(TGame game)
        {
            this.game = game;
        }

        public abstract void ClickAt(ChessPosition position);

        public abstract event Action StateChanged;
    }
}

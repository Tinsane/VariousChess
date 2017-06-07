using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;

namespace WarChess.Application
{
    public abstract class ChessAlikeApp<TGame> : IChessAlikeApp<TGame>
        // todo: where TGame : IChessAlike<TCell>
    {
        private readonly int width;
        private readonly int height;
        protected readonly TGame game;

        public TGame Game => game;

        public ChessAlikeApp(int width, int height, TGame game)
        {
            this.width = width;
            this.height = height;
            this.game = game;
        }

        public abstract void ClickAt(ChessPosition position);

        public abstract event Action StateChanged;
    }
}

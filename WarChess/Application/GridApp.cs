using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;

namespace WarChess.Application
{
    public abstract class GridApp<TGame>
    {
        private readonly int width;
        private readonly int height;
        public readonly TGame game;

        public GridApp(int width, int height, TGame game)
        {
            this.width = width;
            this.height = height;
            this.game = game;
        }
    }
}

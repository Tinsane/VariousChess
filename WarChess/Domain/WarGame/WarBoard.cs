using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Domain.WarGame
{
    public class WarBoard<TCell> : IChessBoard<TCell>
        where TCell : class, IChessAlikePiece
    {
        private readonly IChessAlikeGame<TCell> game;

        public WarBoard(IChessAlikeGame<TCell> game)
        {
            this.game = game;
        }

        public int RowCount => game.Board.RowCount;
        public int ColumnCount => game.Board.ColumnCount;

        public TCell this[ChessPosition position] 
            => game.Board[position]?.Color == game.WhoseTurn ? game.Board[position] : null;
    }
}

using WarChess.Domain.ChessAlike;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.Castling
{
    public class ShortCastling : Castling
    {
        public ShortCastling(GridPosition2D from, GridPosition2D to) : base(new Point2D(0, 2),
            new GridPosition2D(from.X, Utils.BoardSize - 1), from, to)
        {
        }
    }
}
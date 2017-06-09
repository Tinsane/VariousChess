using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.Castling
{
    public class LongCastling : Castling
    {
        public LongCastling(GridPosition2D from, GridPosition2D to) : base(
            new Point2D(0, -2), new GridPosition2D(from.X, 0), from, to)
        {
        }
    }
}
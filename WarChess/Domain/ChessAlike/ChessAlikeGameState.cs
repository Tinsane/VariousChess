using WarChess.Domain.ChessAlike.Cells;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike
{
    // TODO
    public abstract class ChessAlikeGameState<TCell>
        : IGridGameState2D<TCell>
        where TCell : IChessAlikeCell
    {
        protected ChessAlikeGameState(BoundedGridField2D<TCell> field, int currentPlayerId)
        {
            Field = field;
            CurrentPlayerId = currentPlayerId;
        }

        public int CurrentPlayerId { get; }

        public BoundedGridField2D<TCell> Field { get; }
    }
}
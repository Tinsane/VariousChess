using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike
{
    public abstract class ChessAlikeGameState<TCell>
        : IGridGameState2D<TCell>
        where TCell : ChessAlikeCell
    {
        protected ChessAlikeGameState(BoundedGridField2D<TCell> field, int currentPlayerId)
        {
            Field = field;
            CurrentPlayerId = currentPlayerId;
        }

        public int CurrentPlayerId { get; }

        public BoundedGridField2D<TCell> Field { get; }

        public abstract bool IsValid { get; }
    }
}
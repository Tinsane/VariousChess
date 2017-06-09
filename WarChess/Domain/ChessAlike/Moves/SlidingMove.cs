using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public abstract class SlidingMove<TGameState, TCell, TPiece> : DirectedMove<TGameState, TCell, TPiece>
        where TGameState : ChessAlikeGameState<TCell, TPiece>
        where TCell : ChessAlikeCell<TPiece>
        where TPiece : IPiece
    {
        protected SlidingMove(Point2D step, GridPosition2D from, GridPosition2D to) : base(step, from, to) { }

        public override bool IsValid(TGameState gameState)
        {
            if (!base.IsValid(gameState) ||
                !Step.Divides((Point2D) To - (Point2D) From))
                return false;
            for (var cell = (Point2D) From + Step;
                cell != (Point2D) To;
                cell = cell + Step)
                if (gameState.Field[(GridPosition2D) cell].ContainsPiece)
                    return false;
            return true;
        }
    }
}
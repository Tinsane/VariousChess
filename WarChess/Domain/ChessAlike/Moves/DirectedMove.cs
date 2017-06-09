using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public abstract class DirectedMove<TGameState, TCell, TPiece> : IChessAlikeMove<TGameState, TCell, TPiece>
        where TGameState : ChessAlikeGameState<TCell, TPiece>
        where TCell : ChessAlikeCell<TPiece>
        where TPiece : IPiece
    {
        protected DirectedMove(Point2D step, GridPosition2D from, GridPosition2D to)
        {
            Step = step;
            From = from;
            To = to;
        }

        public Point2D Step { get; }
        public GridPosition2D From { get; }

        public GridPosition2D To { get; }

        public TGameState Make(TGameState gameState)
        {
            if (!IsValid(gameState))
                return null;
            var resultGameState = Apply(gameState);
            return resultGameState.IsValid() ? resultGameState : null;
        }

        public virtual bool IsValid(TGameState gameState)
        {
            var field = gameState.Field;
            return field[From].ContainsPiece &&
                   field[From].Piece.PlayerId == gameState.CurrentPlayerId &&
                   (!gameState.Field[To].ContainsPiece || gameState.Field[To].Piece.PlayerId !=
                    gameState.CurrentPlayerId);
        }

        protected abstract TGameState Apply(TGameState gameState);
    }
}
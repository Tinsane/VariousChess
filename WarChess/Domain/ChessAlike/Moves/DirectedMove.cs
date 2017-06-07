using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    public abstract class DirectedMove<TGameState, TCell> : IChessAlikeMove<TGameState, TCell>
        where TGameState : ChessAlikeGameState<TCell>
        where TCell : ChessAlikeCell
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
            return resultGameState.IsValid ? resultGameState : null;
        }

        protected bool IsValid(TGameState gameState)
        {
            var field = gameState.Field;
            return field.Contains(From) &&
                   field.Contains(To) &&
                   field[From].ContainsPiece &&
                   field[From].Piece.PlayerId == gameState.CurrentPlayerId &&
                   (!gameState.Field[To].ContainsPiece || gameState.Field[To].Piece.PlayerId != gameState.CurrentPlayerId);
        }

        protected abstract TGameState Apply(TGameState gameState);
    }
}
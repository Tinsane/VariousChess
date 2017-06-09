using WarChess.Domain.Chess.Moves.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Moves.PawnMoves
{
    public abstract class PawnMove : ChessJump
    {
        protected readonly int PawnOwnerId;

        protected PawnMove(int pawnOwnerId, Point2D step, GridPosition2D from, GridPosition2D to) : base(
            pawnOwnerId == Utils.WhitePlayerId ? step : -step, from, to)
        {
            PawnOwnerId = pawnOwnerId;
        }

        protected new bool IsValid(ChessGameState gameState) => base.IsValid(gameState) &&
                                                                gameState.Field[From].Piece.PlayerId == PawnOwnerId;

        protected override ChessGameState Apply(ChessGameState gameState) => gameState.MovePiece(From, To,
            GetMovedVisitor.GetMoved);
    }
}
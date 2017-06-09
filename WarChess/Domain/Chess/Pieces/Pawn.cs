using System;
using System.Collections.Generic;
using WarChess.Domain.Chess.Moves;
using WarChess.Domain.Chess.Moves.PawnMoves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(int playerId, bool wasMoved, Func<ChessPiece> transformer) : base(playerId)
        {
            WasMoved = wasMoved;
            Transformer = transformer;
        }

        public bool WasMoved { get; }
        internal Func<ChessPiece> Transformer { get; }

        public override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }

        public override IEnumerable<Func<GridPosition2D, GridPosition2D, IChessMove>> GetPossibleMoves()
        {
            for (var pawnOwnerId = 0; pawnOwnerId < Utils.PlayersCount; ++pawnOwnerId)
            {
                var id = pawnOwnerId;
                yield return (from, to) => new PawnForwardMove(id, from, to, Transformer);
                yield return (from, to) => new PawnCapturing(id, new Point2D(1, 1), from, to, Transformer);
                yield return (from, to) => new PawnCapturing(id, new Point2D(1, -1), from, to, Transformer);
                yield return (from, to) => new PawnDoubleJump(id, from, to);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WarChess.Domain.Chess.Moves;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Pieces
{
    public class Rook : ChessPiece
    {
        private static readonly Point2D[] Steps =
        {
            new Point2D(1, 0),
            new Point2D(-1, 0),
            new Point2D(0, 1),
            new Point2D(0, -1)
        };

        public Rook(int playerId, bool wasMoved) : base(playerId) { WasMoved = wasMoved; }

        public bool WasMoved { get; }

        public override void AcceptVisitor(IChessPieceVisitor visitor) { visitor.Visit(this); }

        public override IEnumerable<Func<GridPosition2D, GridPosition2D, IChessMove>> GetPossibleMoves()
            => Steps.Select<Point2D, Func<GridPosition2D, GridPosition2D, IChessMove>>(
                step => ((from, to) => new RookMove(step, from, to)));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.Pieces.Visitors;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.WarChess
{
    public static class WarChessUtils
    {
        public static bool PawnCanAttack(this ChessGameState state)
        {
            foreach (var position in state.Field.Positions)
            {
                var cell = state.Field[position];
                if (!cell.ContainsPiece)
                    continue;
                var piece = cell.Piece;
                if (!PawnCheckVisitor.IsPawn(piece))
                    continue;
                if (new[] { new Point2D(1, 1), new Point2D(1, -1) }.Select(
                        direction => (GridPosition2D)((Point2D)position +
                                                      (state.CurrentPlayerId == Utils.WhitePlayerId
                                                          ? direction
                                                          : -direction)))
                    .Where(target => state.Field.Contains(target))
                    .SelectMany(target => piece.GetPossibleMoves(position, target))
                    .Any(move => !ReferenceEquals(move.Make(state), null)))
                    return true;
            }
            return false;
        }
    }
}

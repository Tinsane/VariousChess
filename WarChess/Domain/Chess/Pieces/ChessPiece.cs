using System;
using System.Collections.Generic;
using System.Linq;
using WarChess.Domain.Chess.Moves;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess.Pieces
{
    public abstract class ChessPiece : IPiece
    {
        protected ChessPiece(int playerId) { PlayerId = playerId; }

        public int PlayerId { get; }

        public abstract void AcceptVisitor(IChessPieceVisitor visitor);

        public abstract IEnumerable<Func<GridPosition2D, GridPosition2D, IChessMove>> GetPossibleMoves();

        public IEnumerable<IChessMove> GetPossibleMoves(GridPosition2D from, GridPosition2D to)
            => GetPossibleMoves().Select(moveGenerator => moveGenerator(from, to));
    }
}
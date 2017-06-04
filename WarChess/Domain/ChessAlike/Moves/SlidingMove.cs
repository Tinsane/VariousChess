using System;
using WarChess.Domain.ChessAlike.PieceArchitecture;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.ChessAlike.Moves
{
    internal class SlidingMove<TGameState> : IGridGame2DMove<TGameState, Piece>
        where TGameState : IGridGameState2D<Piece>
    {
        public TGameState Make(TGameState gameState)
        {
            throw new NotImplementedException();
        }
    }
}
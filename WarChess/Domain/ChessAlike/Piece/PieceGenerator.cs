using System;

namespace WarChess.Domain.ChessAlike.Piece
{
    public class PieceGenerator
    {
        /// <summary>
        /// </summary>
        /// <param name="ctor">Gets playerId and returns IPiece.</param>
        public PieceGenerator(Func<int, Piece> ctor)
        {
            Ctor = ctor;
        }

        protected Func<int, Piece> Ctor { get; }

        public Piece GetPiece(int playerId)
        {
            return Ctor(playerId);
        }
    }
}
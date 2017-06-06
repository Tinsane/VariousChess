using System;
using System.Collections.Generic;

namespace WarChess.Domain.ChessAlike.Piece
{
    public class PieceSetGenerator
    {
        private List<PieceGenerator> Info { get; } = new List<PieceGenerator>();

        public int AddPiece(string name, Func<int, int, Piece> pieceGenerator)
        {
            var pieceId = Info.Count;
            Info.Add(new PieceGenerator(playerId => pieceGenerator(pieceId, playerId)));
            return pieceId;
        }

        public PieceSet GetPieceSet()
        {
            var pieceSet = new PieceSet(Info.ToArray());
            Info.Clear();
            return pieceSet;
        }
    }
}
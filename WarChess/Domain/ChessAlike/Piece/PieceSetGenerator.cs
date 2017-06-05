using System;
using System.Collections.Generic;

namespace WarChess.Domain.ChessAlike.Piece
{
    public class PieceSetGenerator
    {
        private List<PieceInfo> Info { get; } = new List<PieceInfo>();

        public void AddPiece(string name, Func<int, int, IPiece> pieceGenerator)
        {
            var pieceId = Info.Count;
            Info.Add(new PieceInfo(name, playerId => pieceGenerator(pieceId, playerId)));
        }

        public PieceSet GetPieceSet()
        {
            var pieceSet = new PieceSet(Info.ToArray());
            Info.Clear();
            return pieceSet;
        }
    }
}
using System;

namespace WarChess.Domain.ChessAlike.Piece
{
    public class PieceInfo
    {
        public PieceInfo(string name, Func<int, IPiece> generator)
        {
            Name = name;
            Generator = generator;
        }

        public string Name { get; }
        public Func<int, IPiece> Generator { get; }
    }
}
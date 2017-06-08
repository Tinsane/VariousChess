using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.ChessAlike
{
    public abstract class ChessAlikeCell<TPiece> : ICell
        where TPiece : IPiece
    {
        protected ChessAlikeCell(TPiece piece) { Piece = piece; }

        public TPiece Piece { get; }
        public bool ContainsPiece => !ReferenceEquals(Piece, null);
    }
}
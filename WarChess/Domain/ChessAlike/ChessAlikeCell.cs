using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.ChessAlike
{
    public abstract class ChessAlikeCell : ICell
    {
        protected ChessAlikeCell(IPiece piece) { Piece = piece; }

        public IPiece Piece { get; }
        public bool ContainsPiece => !ReferenceEquals(Piece, null);
    }
}
using WarChess.Domain.AbstractGame;

namespace WarChess.Domain.ChessAlike.Piece
{
    public interface IPiece : ICell
    {
        int PlayerId { get; }
        int TypeId { get; }
    }
}
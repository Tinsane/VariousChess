using WarChess.Domain.ChessAlike.Cells;

namespace WarChess.Domain.ChessAlike.Piece
{
    public interface IPiece : IChessAlikeCell
    {
        int PlayerId { get; }
        int TypeId { get; }
    }
}
using WarChess.Domain.AbstractGame.Cells;

namespace WarChess.Domain.ChessAlike.Cells
{
    public interface IChessAlikeCell : ICell
    {
        int? PieceId { get; }
    }
}
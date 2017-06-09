using WarChess.Domain.Chess.Pieces;

namespace WarChess.Domain.Chess
{
    public interface IPawnTransformer
    {
        ChessPiece GetTransformed();
    }
}
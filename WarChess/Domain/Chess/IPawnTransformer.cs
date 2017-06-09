using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Domain.Chess
{
    public interface IPawnTransformer
    {
        ChessPiece GetTransformed(Color pawnColor);
    }
}
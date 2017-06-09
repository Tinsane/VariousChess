using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Domain.Chess
{
    public class QueenPawnTransformer : IPawnTransformer
    {
        public ChessPiece GetTransformed(Color pawnColor) => new Queen((int) pawnColor);
    }
}
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike.Moves;

namespace WarChess.Domain.Chess.Moves
{
    public interface IChessMove : IChessAlikeMove<ChessGameState, ChessCell, ChessPiece>
    {
    }
}
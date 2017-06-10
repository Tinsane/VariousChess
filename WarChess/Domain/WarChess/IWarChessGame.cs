using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.Domain.WarChess
{
    public interface IWarChessGame : IChessGame
    {
        bool PawnCanAttack { get; }
    }
}
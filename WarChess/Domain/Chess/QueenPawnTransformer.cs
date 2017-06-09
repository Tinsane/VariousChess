using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Domain.Chess
{
    public class QueenPawnTransformer : IPawnTransformer
    {
        public ChessPiece GetTransformed(Color pawnColor)
        {
            return new Queen((int) pawnColor);
        }
    }
}

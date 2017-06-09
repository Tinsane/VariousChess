using System;
using WarChess.Domain.Chess;

namespace WarChess.Domain.ChessAlikeApi
{
    public static class ChessNotationConverter
    {
        public static ChessPosition GetChessPosition(this string chessNotation)
        {
            if (!char.IsLower(chessNotation[0]))
                throw new ArgumentException("Invalid letter");
            if (!char.IsDigit(chessNotation[1]) || chessNotation[1] == '0')
                throw new ArgumentException("Invalid digit");
            return new ChessPosition(chessNotation[1] - '1', chessNotation[0] - 'a');
        }

        public static string GetChessNotation(this ChessPosition position) => $"{(char)('a' + position.Y)}{position.X + 1}";
    }
}
using System;
using WarChess.Domain.AbstractGame;
using WarChess.Domain.Chess;

namespace WarChess.Domain.ChessAlikeApi
{
    public class ChessNotationConverter : INotationConverter<ChessPosition>
    {
        public static readonly ChessNotationConverter Converter = new ChessNotationConverter();
        private ChessNotationConverter() { }

        public ChessPosition FromNotation(string notation)
        {
            if (!char.IsLower(notation[0]))
                throw new ArgumentException("Invalid letter");
            if (!char.IsDigit(notation[1]) || notation[1] == '0')
                throw new ArgumentException("Invalid digit");
            return new ChessPosition(notation[1] - '1', notation[0] - 'a');
        }

        public string ToNotation(ChessPosition position) => $"{'a' + position.Y}{position.X + 1}";
    }
}
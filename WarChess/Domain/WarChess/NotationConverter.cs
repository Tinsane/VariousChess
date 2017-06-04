using System;
using WarChess.Domain.AbstractGame;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.WarChess
{
    public class ChessNotationConverter : INotationConverter<GridPosition2D>
    {

        public GridPosition2D FromNotation(string notation)
        {
            if (!char.IsLower(notation[0]))
                throw new ArgumentException("Invalid letter");
            if (!char.IsDigit(notation[1]) || notation[1] == '0')
                throw new ArgumentException("Invalid digit");
            return new GridPosition2D(notation[1] - '1', notation[0] - 'a');
        }

        public string ToNotation(GridPosition2D position)
        {
            return $"{'a' + position.Y}{position.X+1}";
        }
    }
}
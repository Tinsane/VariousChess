using WarChess.Domain.Figures;

namespace WarChess.Domain
{
    public interface IField
    {
        IFigure this[Position position] { get; }

        /// <summary>
        /// Column is a line along which pawns move.
        /// Numbered by integers.
        /// </summary>
        int ColumnsCount { get; }

        /// <summary>
        /// Row is a line along which figures stand in the beginning.
        /// Numbered by letters.
        /// </summary>
        int RowsCount { get; }
    }
}

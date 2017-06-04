namespace WarChess.Domain.AbstractChess
{
    /// <summary>
    ///     chess piece - так переводится шахматная фигура
    /// </summary>
    public interface IPiece
    {
        Color Color { get; }

        /// <summary>
        ///     King, Queen, ...
        ///     Не enum, потому что нужна расширяемость.
        ///     Конечно же, в конкретной реализации игры нужно чтобы наружу торчали строковые константы с названиями фигур
        /// </summary>
        string Name { get; }
    }
}
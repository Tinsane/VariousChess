namespace WarChess.Domain.Figures
{
    /// <summary>
    /// Этот интерфейс должны реализовывать все классы фигур.
    /// Предполагается, что на каждый тип фигуры будет по своему классу.
    /// </summary>
    public interface IFigure
    {
        Color Color { get; }

        /// <summary>
        /// Это понадобится для визуализации
        /// </summary>
        void AcceptVisitor(IFigureVisitor figureVisitor);
    }
}

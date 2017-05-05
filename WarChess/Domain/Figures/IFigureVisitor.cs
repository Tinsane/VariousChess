namespace WarChess.Domain.Figures
{
    public interface IFigureVisitor
    {
        // TODO: Сделать то же самое для всех классов фигур.
        void Visit(King king);
    }
}

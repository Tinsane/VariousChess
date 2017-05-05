namespace WarChess.Domain.Figures
{
    public class King : IFigure
    {
        public Color Color { get; }
        public void AcceptVisitor(IFigureVisitor figureVisitor)
        {
            figureVisitor.Visit(this);
        }
    }
}

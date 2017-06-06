namespace WarChess.Domain.AbstractGame.Cells
{
    public class EmptyCell : Cell
    {
        internal override bool AcceptVisitor(EmptyCellVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
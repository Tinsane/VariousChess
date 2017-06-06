namespace WarChess.Domain.AbstractGame.Cells
{
    public abstract class NonEmptyCell : Cell
    {
        internal override bool AcceptVisitor(EmptyCellVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
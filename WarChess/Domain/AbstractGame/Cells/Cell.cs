namespace WarChess.Domain.AbstractGame.Cells
{
    public abstract class Cell
    {
        internal abstract bool AcceptVisitor(EmptyCellVisitor visitor);

        public bool IsEmpty()
        {
            return AcceptVisitor(new EmptyCellVisitor());
        }
    }
}
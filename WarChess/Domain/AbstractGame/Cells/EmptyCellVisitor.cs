namespace WarChess.Domain.AbstractGame.Cells
{
    internal class EmptyCellVisitor
    {
        public bool Visit(EmptyCell cell)
        {
            return true;
        }

        public bool Visit(NonEmptyCell cell)
        {
            return false;
        }
    }
}
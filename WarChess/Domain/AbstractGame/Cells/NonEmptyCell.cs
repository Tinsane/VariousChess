namespace WarChess.Domain.AbstractGame.Cells
{
    public abstract class NonEmptyCell : ICell
    {
        public bool IsEmpty => false;
    }
}
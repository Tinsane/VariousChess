namespace WarChess.Domain.AbstractGame.Cells
{
    public class EmptyCell : ICell
    {
        public bool IsEmpty => true;
    }
}
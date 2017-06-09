namespace WarChess.Domain.GridGame2D
{
    public class Size2D
    {
        public Size2D(int rowsCnt, int columnsCnt)
        {
            RowsCnt = rowsCnt;
            ColumnsCnt = columnsCnt;
        }

        public int RowsCnt { get; }
        public int ColumnsCnt { get; }
    }
}
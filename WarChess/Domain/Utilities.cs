namespace WarChess.Domain
{
    public static class Utilities
    {
        public static bool IsInInterval(int value, int leftBound, int rightBound)
        {
            return leftBound <= value && value < rightBound;
        }
    }
}
namespace WarChess.Domain
{
    public static class Utilities // От Вани: Кажется, это нужно писать в слое инфраструктуры.
    {
        public static bool IsInInterval(int value, int leftBound, int rightBound)
        {
            return leftBound <= value && value < rightBound;
        }
    }
}
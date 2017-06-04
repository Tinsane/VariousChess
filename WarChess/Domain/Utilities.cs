using System;

namespace WarChess.Domain
{
    public static class Utilities
    {
        public static bool IsInInterval(int value, int leftBound, int rightBound)
        {
            return leftBound <= value && value < rightBound;
        }

        public static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (true)
            {
                if (b == 0) return a;
                var a1 = a;
                a = b;
                b = a1 % b;
            }
        }
    }
}
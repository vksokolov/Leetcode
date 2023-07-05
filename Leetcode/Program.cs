using System;

namespace Leetcode
{
    class Program
    {
        public static void Main()
        {
            var s = new Solution();
            Print(s.GetResult());
        }

        private static void Print(string msg) =>
            Console.WriteLine(msg);
    }

    internal partial class Solution
    {
        public string GetResult()
        {
            return MySqrt(int.MaxValue).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public int MySqrt(int x)
        {
            int maxIntSqrt = 46340;
            int leftBound = 0;
            int rightBound = x/2;

            if (rightBound > maxIntSqrt)
                rightBound = maxIntSqrt;

            while (leftBound * leftBound < x && leftBound < maxIntSqrt)
            {
                int mid = (leftBound + rightBound) / 2;
                if (mid * mid > x) rightBound = mid;
                else leftBound = mid + 1;
            }

            return leftBound * leftBound <= x ? leftBound : leftBound - 1;
        }
    }
}

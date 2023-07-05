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
            int[] arr = { 8,9 };
            return PlusOne(arr).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            if (digits[^1] != 9)
            {
                digits[^1]++;
                return digits;
            }
            
            bool overflow = true;

            
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    overflow = false;
                    digits[i]++;
                }
                else
                    digits[i] = 0;

                if (!overflow) return digits;
            }

            if (overflow)
            {
                digits = new int[digits.Length + 1];
                digits[0] = 1;
            }
            return digits;
        }
    }
}

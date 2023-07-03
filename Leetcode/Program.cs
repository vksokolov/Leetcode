using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        public static void Main()
        {
            Solution s = new Solution();
            Print(s.GetResult());
        }

        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    internal partial class Solution
    {
        public string GetResult()
        {
            return RomanToInt("LVIII").ToString();
        }
    }

    internal partial class Solution
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanToIntChars = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };
            
            var stack = new Stack<char>();
            var lastChar = 'I';
            var result = 0;

            foreach (var c in s)
                stack.Push(c);

            while (stack.TryPop(out var c))
            {
                var mult = romanToIntChars[c] < romanToIntChars[lastChar] ? -1 : 1;
                result += romanToIntChars[c] * mult;
                lastChar = c;
            }

            return result;
        }
    }
}

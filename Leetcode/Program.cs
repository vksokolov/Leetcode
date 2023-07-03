using System;
using System.Collections.Generic;

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
            return IsValid("[").ToString();
        }
    }

    internal partial class Solution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var map = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
            };
            
            foreach (var c in s)
            {
                if (IsOpeningBracket(c))
                    stack.Push(c);
                else if (!stack.TryPop(out var sc))
                    return false;
                else if (map[sc] != c) 
                    return false;
            }

            return !stack.TryPeek(out _);

            bool IsOpeningBracket(char c) => c == '(' || c == '{' || c == '[';
        }
    }
}

using System;
using System.Diagnostics;

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
        public const bool Benchmark = false;
        private static Stopwatch _watch = new Stopwatch();

        public string GetResult()
        {
            //var func = () => IsPalindrome("ab_a");
            var func = () => IsPalindrome("A man, a plan, a canal: Panama");
            //var func = () => IsPalindrome("_");
            
            //var func = () => char.IsLetterOrDigit('c');
            //var func = () => IsEqual2('A', 'a');
            if (Benchmark)
            {
                int iterations = 999999;
                _watch.Start();

                for (int i = 0; i < iterations; i++)
                    func();

                _watch.Stop();
                return func().ToPrettyString() + $"\n{iterations} iterations, {_watch.ElapsedMilliseconds} ms";
            }

            var result = func();
            return result.ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public bool IsPalindrome(string s)
        {
            int i, j;
            for (i = 0, j = s.Length - 1; i <= j;)
            {
                while (!IsValid(s[i++]) & i <= j) { }
                while (i <= j & !IsValid(s[j--])) { }
                if (!IsEqual(s[i - 1] , s[j + 1])) return false;
            }

            return true;

            bool IsValid(char c) => c 
                is >= '0' and <= '9' 
                or >= 'A' and <= 'Z' 
                or >= 'a' and <= 'z';
            
            bool IsEqual(char a, char b) =>
                a is >= 'A' and <= 'Z' && b is >= 'a' and <= 'z' ||
                a is >= 'a' and <= 'z' && b is >= 'A' and <= 'Z'
                    ? ((a - 'A') & 0b111) == ((b - 'A') & 0b111)
                    : a == b;
        }
    }
}

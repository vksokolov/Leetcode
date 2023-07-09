using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
            var func = () => IsHappy(19);
            if (Benchmark)
            {
                int iterations = 9999999;
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
        public bool IsHappy(int n)
        {
            long x = n;
            var set = new HashSet<long>();
            var digits = new List<int>(20);

            while (!set.Contains(x))
            {
                digits.Clear();
                set.Add(x);
                Console.WriteLine(x);
                while (x > 0)
                {
                    digits.Add((int)(x%10));
                    x /= 10;
                }

                foreach (var digit in digits) 
                    x += digit * digit;
            }

            return x == 1;
        }
    }
}

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
            var func = () => GetRow(4);
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
        public bool IsPowerOfTwo(int n)
        {
            return n switch
            {
                0b1 => true,
                0b10 => true,
                0b100 => true,
                0b1000 => true,
                0b10000 => true,
                0b100000 => true,
                0b1000000 => true,
                0b10000000 => true,
                0b100000000 => true,
                0b1000000000 => true,
                0b10000000000 => true,
                0b100000000000 => true,
                0b1000000000000 => true,
                0b10000000000000 => true,
                0b100000000000000 => true,
                0b1000000000000000 => true,
                0b10000000000000000 => true,
                0b100000000000000000 => true,
                0b1000000000000000000 => true,
                0b10000000000000000000 => true,
                0b100000000000000000000 => true,
                0b1000000000000000000000 => true,
                0b10000000000000000000000 => true,
                0b100000000000000000000000 => true,
                0b1000000000000000000000000 => true,
                0b10000000000000000000000000 => true,
                0b100000000000000000000000000 => true,
                0b1000000000000000000000000000 => true,
                0b10000000000000000000000000000 => true,
                0b100000000000000000000000000000 => true,
                0b1000000000000000000000000000000 => true,
                _ => false
            };
        }
    }
}

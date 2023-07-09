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
            var func = () => reverseBits(uint.MaxValue - 0b1010101);
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
        public uint reverseBits(uint n)
        {
            var left = (uint)1 << 31;
            uint right = 1;
            for (var i = 0; i < 32; i++)
            {
                n ^= (n & right) << (31 - 2 * i);
                n ^= (n & left) >> (31 - 2 * i);
                n ^= (n & right) << (31 - 2 * i);
                
                left >>= 1;
                right <<= 1;
            }

            return n;
        }
    }
}

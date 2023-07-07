using System;
using System.Collections.Generic;
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
        public IList<int> GetRow(int rowIndex)
        {
            var row = new int[++rowIndex];
            row[0] = 1;
            row[^1] = 1;
            for (var i = 1; i < rowIndex; i++)
            {
                row[i] = 1;
                for (var j = i - 1; j > 0; j--) 
                    row[j] += row[j - 1];
            }

            return row;
        }
    }
}

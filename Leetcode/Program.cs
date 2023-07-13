using System;
using System.Diagnostics;
using System.Text;

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
            var arr = new int[]
            {
                4,3,2
            };
            
            var func = () => MaxSatisfaction(arr);
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
        public int MaxSatisfaction(int[] satisfaction) {
            Array.Sort(satisfaction);

            var totalSum = 0;
            var uniqueSum = 0;
            for (var i = 1; i < satisfaction.Length; i++)
            {
                uniqueSum += satisfaction[^i];
                if (uniqueSum > 0) totalSum += uniqueSum;
                else return totalSum;
            }

            return totalSum;
        }
    }
}

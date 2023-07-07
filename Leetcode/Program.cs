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
            //var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var prices = new int[] { 1,2 };
            var func = () => MaxProfit(prices);
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
        public int MaxProfit(int[] prices)
        {
            var min = int.MaxValue;
            var maxProfit = 0;
            for (var i = 0; i < prices.Length; i++)
            {
                Min(ref min, prices[i]);
                Max(ref maxProfit, prices[i] - min);
            }

            return maxProfit;

            void Max(ref int a, int b) => a = a > b ? a : b;
            void Min(ref int a, int b) => a = a < b ? a : b;
        }
    }
}

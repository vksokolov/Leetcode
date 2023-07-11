using System;
using System.Collections.Generic;
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
        public IList<string> SummaryRanges(int[] nums)
        {
            var result = new List<string>();
            
            if (nums.Length == 0) return result;

            var rangeStart = nums[0];
            var rangeEnd = rangeStart;
            
            for (var i = 1; i < nums.Length; i++)
            {
                var num = nums[i];

                if (num == rangeEnd + 1)
                    rangeEnd++;
                else
                {
                    AppendRange(rangeStart, rangeEnd);

                    rangeStart = num;
                    rangeEnd = num;
                }
            }
            
            AppendRange(rangeStart, rangeEnd);

            return result;

            void AppendRange(int left, int right) => 
                result.Add(rangeEnd != rangeStart ? $"{left}->{right}" : $"{left}");
        }
    }
}





if (rangeStart == rangeEnd && num != ++rangeEnd)
{
    rangeStart = rangeEnd;
}
}
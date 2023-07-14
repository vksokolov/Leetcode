﻿using System;
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
            var arr = new int[] { 0, 2, 1, 5, 3, 4 };
            var func = () => BuildArray(arr);
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
        public int[] BuildArray(int[] nums)
        {
            var ans = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++) 
                ans[i] = nums[nums[i]];

            return ans;
        }
    }
}

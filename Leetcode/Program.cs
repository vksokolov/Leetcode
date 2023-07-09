﻿using System;
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
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var map = new Dictionary<int, int>(nums.Length);
            for (var i = 0; i < nums.Length; i++)
            {
                if (!map.TryGetValue(nums[i], out var val) || (i-val) > k)
                    map[nums[i]] = i;
                else
                    return true;
            }

            return false;
        }
    }
}

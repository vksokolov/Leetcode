using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Leetcode;

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
        var func = () => FindMatrix(new[] {8,8,8,8,2,4,4,2,4});
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
    public IList<IList<int>> FindMatrix(int[] nums) {
        var map = new Dictionary<int, int>();
        var max = 0;
        foreach (var num in nums)
        {
            map.TryAdd(num, 0);
            map[num]++;
            if (map[num] > max)
                max = map[num];
        }
        
        var result = new List<IList<int>>();
        for (var i = 0; i < max; i++)
        {
            var row = new List<int>();
            foreach (var (key, value) in map)
            {
                if (value > i)
                    row.Add(key);
            }
            if (row.Count > 0)
                result.Add(row);
        }

        return result;
    }
}
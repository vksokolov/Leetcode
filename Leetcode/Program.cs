using System;
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
    public int[] CountPoints(int[][] points, int[][] queries)
    {
        var result = new int[queries.Length];

        for (var queryIndex = 0; queryIndex < queries.Length; queryIndex++)
        {
            var query = queries[queryIndex];
            var rSqr = query[2] * query[2];
            foreach (var point in points)
            {
                if (point[0] - query[0] + point[1] - query[1] <= rSqr)
                    result[queryIndex]++;
            }
        }

        return result;
    }

    public int[] CountPoints2(int[][] points, int[][] queries)
    {
        var res = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var r = query[2] * query[2];
            foreach (var point in points)
                if ((point[0] - query[0]) * (point[0] - query[0]) + (point[1] - query[1]) * (point[1] - query[1]) <= r)
                    res[i]++;
        }

        return res;
    }
}
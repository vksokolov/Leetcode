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
        var arr = "[[59,88,44],[3,18,38],[21,26,51]]".To2dArray<int>();
        var func = () => MaxIncreaseKeepingSkyline(arr);
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
    public int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        var result = 0;
        var topToBottom = new int[grid.Length];
        var leftToRight = new int[grid[0].Length];
        
        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (topToBottom[j] < grid[i][j])
                topToBottom[j] = grid[i][j];

            if (leftToRight[j] < grid[j][i])
                leftToRight[j] = grid[j][i];
        }
        
        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
            result += Math.Min(topToBottom[i], leftToRight[j]) - grid[i][j];

        return result;
    }
}
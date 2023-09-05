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
        var func = () => NumTrees(3);
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
    public int NumTrees(int n)
    {
        var ans = new int[n + 1];
        ans[0] = 1;
        ans[1] = 1;

        for (var i = 2; i <= n; ++i)
        for (var j = 0; j < i; ++j)
            ans[i] += ans[j] * ans[i - j - 1];

        return ans[n];
    }
}
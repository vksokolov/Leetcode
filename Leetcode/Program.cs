using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
    public IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        return groupSizes
            .Select((size, index) => new { size, index })
            .GroupBy(x => x.size)
            .SelectMany(g => g
                .Select((x, i) => new { x.index, Group = i / g.Key })
                .GroupBy(x => x.Group)
                .Select(grp => (IList<int>)grp.Select(x => x.index).ToList())
            ).ToList();
    }
}
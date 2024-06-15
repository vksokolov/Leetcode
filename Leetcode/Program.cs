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
        var result = new List<IList<int>>();
        var dict = new Dictionary<int, List<int>>();

        for (var i = 0; i < groupSizes.Length; i++)
        {
            dict.TryAdd(groupSizes[i], new List<int>());
            dict[groupSizes[i]].Add(i);
        }

        foreach (var (size, group) in dict)
            for (var i = 0; i < group.Count; i += size)
                result.Add(group.GetRange(i, size));

        return result;
    }
}
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
        var pref = new[]{5, 2, 0, 3, 1};
        var func = () => FindArray(pref);
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
    public int[] FindArray(int[] pref)
    {
        var tmp = 0;
        for (int i = 1; i < pref.Length; i++)
        {
            tmp ^= pref[i-1];
            pref[i] ^= tmp;
        }

        return pref;
    }
}
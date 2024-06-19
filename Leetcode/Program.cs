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
        var func = () => NumberOfBeams(new []{"011001","000000","010100","001000"});
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
    public int NumberOfBeams(string[] bank)
    {
        var beams = 0;
        var devicesInPrevRow = 0;
        var devicesInCurRow = 0;
        foreach (var row in bank)
        {
            foreach (var cell in row) 
                devicesInCurRow += cell - '0';

            if (devicesInCurRow == 0)
                continue;
            
            beams += devicesInCurRow * devicesInPrevRow;
            devicesInPrevRow = devicesInCurRow;
            devicesInCurRow = 0;
        }

        return beams;
    }
}
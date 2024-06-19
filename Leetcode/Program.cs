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
        var func = () => MinOperations("001011");
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
    public int[] MinOperations(string boxes) {
        // got forward and backward
        
        var n = boxes.Length;
        var turnsToMoveFromTheLeft = 0;
        var turnsToMoveFromTheRight = 0;
        var ballsOnTheLeft = 0;
        var ballsOnTheRight = 0;
        var result = new int[n];
        
        for (var i = 1; i < n; i++)
        {
            ballsOnTheLeft += boxes[i - 1] - '0';
            turnsToMoveFromTheLeft += ballsOnTheLeft;
            result[i] += turnsToMoveFromTheLeft;
            
            ballsOnTheRight += boxes[n - i] - '0';
            turnsToMoveFromTheRight += ballsOnTheRight;
            result[n - i - 1] += turnsToMoveFromTheRight;
        }

        return result;
    }
}
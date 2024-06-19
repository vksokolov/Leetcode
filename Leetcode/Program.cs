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
        var turnsToMoveFromTheLeft = new int[n];
        var turnsToMoveFromTheRight = new int[n];
        var ballsOnTheLeft = 0;
        var ballsOnTheRight = 0;
        for (var i = 1; i < n; i++)
        {
            ballsOnTheLeft += boxes[i - 1] - '0';
            turnsToMoveFromTheLeft[i] += turnsToMoveFromTheLeft[i-1] + ballsOnTheLeft;
            
            ballsOnTheRight += boxes[n - i] - '0';
            turnsToMoveFromTheRight[n - i - 1] += turnsToMoveFromTheRight[n - i] + ballsOnTheRight;
        }
        
        for (var i = 0; i < n; i++)
            turnsToMoveFromTheLeft[i] += turnsToMoveFromTheRight[i];
        
        return turnsToMoveFromTheLeft;
    }
}
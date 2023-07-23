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
        var func = () => MinimumSum(2932);
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
    public int MinimumSum(int num)
    {
        var digits = new int[4];
        var sum = 0;
        int i;
        
        for(i=0;i<4;i++)
        {
            digits[i] = num % 10;
            num /= 10;
        }
        
        Array.Sort(digits);
        for (i = 0; i < 2;) 
            sum += digits[i++] * 10 + digits[^i];

        return sum;
    }
}
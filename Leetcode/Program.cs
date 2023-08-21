using System;
using System.Diagnostics;
using System.Text;

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
        var func = () => Reverse(-2147483412);
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
    public int Reverse(int x)
    {
        if (x is 0 or int.MinValue) 
            return 0;
        
        var max = int.MaxValue / 10;
        var result = 0;
        var isPositive = x > 0;
        if (!isPositive)
            x = -x;
        while (x > 0)
        {
            if (result > max)
                return 0;

            result = result * 10 + x % 10;
            x /= 10;
        }
        
        return isPositive ? result : -result;
    }
}
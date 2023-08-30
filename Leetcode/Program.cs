using System;
using System.Collections.Generic;
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
        var func = () => IntToRoman(1994);
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
    public string IntToRoman(int num)
    {
        var result = new StringBuilder();
        var dec = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        var rom = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X","IX", "V", "IV", "I" };
        
        for(var i=0;i<dec.Length; i++)
        {
            while(num >= dec[i])
            {
                num -= dec[i];
                result.Append(rom[i]);
            }
        }
        
        return result.ToString();
    }
}
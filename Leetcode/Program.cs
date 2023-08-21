﻿using System;
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
        var func = () => Convert("PAYPALISHIRING", 4);
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
    public string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;
        var mid = numRows - 1;
        var charsInLoop = mid << 1;
        var i = 0;
        Span<char> result = stackalloc char[s.Length];
        for (var row = 0; row < numRows; row++)
        {
            var index = row;
            var doubleDistanceToMid = (mid - row) << 1;
            
            while (index < s.Length)
            {
                result[i++] = s[index];
                if (row == 0 || row == mid)
                    index += charsInLoop;
                else
                {
                    var res = index % charsInLoop;
                    if (res > mid)
                        index += charsInLoop - doubleDistanceToMid;
                    else
                        index += doubleDistanceToMid;
                }
            }
        }
        
        return new string(result);
    }
}

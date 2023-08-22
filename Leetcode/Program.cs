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
        var func = () => MyAtoi("-2147483648");
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
    public int MyAtoi(string s)
    {
        bool? isPositive = default;
        var digitFound = false;
        var result = 0L;
        foreach (var c in s)
        {
            switch (c)
            {
                case ' ':
                    if (digitFound || isPositive.HasValue)
                        return GetSignedResult();
                    break;
                case '-' or '+':
                    if (digitFound || isPositive.HasValue)
                        return GetSignedResult();
                    
                    isPositive = c == '+';
                    break;
                case <'0' or >'9':
                    return GetSignedResult();
                default:
                {
                    var digit = c - '0';
                    if (digit is <10 and >= 0)
                    {
                        digitFound = true;
                        result = result * 10 + digit;
                        
                        if (isPositive.HasValue && !isPositive.Value && -result <= int.MinValue)
                            return int.MinValue;
                        
                        if (result > int.MaxValue)
                            return int.MaxValue;
                    }
                    break;
                }
            }
        }

        return GetSignedResult();
        
        int GetSignedResult()
        {
            isPositive ??= true;
            return (int)(isPositive.Value ? result : -result);
        }
    }
}
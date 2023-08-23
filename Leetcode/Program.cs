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
    public IList<string> LetterCombinations(string digits) {
        var result = new List<string>();
        if (string.IsNullOrEmpty(digits))
            return result;

        var map = new Dictionary<char, char[]>()
        {
            { '2', new[] { 'a', 'b', 'c' } },
            { '3', new[] { 'd', 'e', 'f' } },
            { '4', new[] { 'g', 'h', 'i' } },
            { '5', new[] { 'j', 'k', 'l' } },
            { '6', new[] { 'm', 'n', 'o' } },
            { '7', new[] { 'p', 'r', 's', 'q' } },
            { '8', new[] { 't', 'u', 'v' } },
            { '9', new[] { 'w', 'x', 'y', 'z' } },
        };

        for (var index = 0; index < digits.Length; index++)
        {
            var digit = digits[index];
            if (!map.TryGetValue(digit, out var symbols))
                continue;

            if (result.Count == 0)
                foreach (var c in symbols)
                    result.Add(c.ToString());
            else
            {
                var initCount = result.Count;
                foreach (var c in symbols)
                    for (var i = 0; i < initCount; i++)
                        result.Add(result[i] + c);
            }
        }

        result.RemoveAll(x => x.Length != digits.Length);
        
        return result;
    }
}
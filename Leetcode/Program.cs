using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        var map = new string[]
        {
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "prsq",
            "tuv",
            "wxyz",
        };
        
        var symbolSequences = digits.Select(d => map[d - '2']).ToArray();
        var combinations = GetAllCombinations1(symbolSequences, digits.Length-1);
        
        return combinations.Select(x => new string(x.ToArray())).ToList();

        IEnumerable<IEnumerable<char>> GetAllCombinations1(IReadOnlyList<IEnumerable<char>> sequences, int sequenceIndex) =>
            sequenceIndex == 0
                ? sequences[0].Select(c => new[] { c })
                : GetAllCombinations1(sequences, sequenceIndex - 1)
                    .SelectMany(_ => sequences[sequenceIndex], (chars, c) => chars.Append(c));
    }
}
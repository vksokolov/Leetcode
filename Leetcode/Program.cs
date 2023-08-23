using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        var sb = new StringBuilder(map[digits[0] - '2']);
        var combinationLength = 1;
        var totalCombinations = map[digits[0] - '2'].Length;

        for (var index = 1; index < digits.Length; index++)
        {
            var digit = digits[index];
            string chars = map[digit - '2'];
            int initialCombinationLength = combinationLength++;
            
            // sb = "abc", chars = "def"
            // sb => "abcabcabc"
            // (abc abc abc)
            //  (d   e   f)
            var sbLength = sb.Length;
            for (var i = 0; i < chars.Length - 1; i++)
            for (var j = 0; j < sbLength; j++)
                sb.Append(sb[j]);
            
            // sb = "abcabcabc", chars = "def"
            // sb => "adbdcdaebeceafbfcf"
            // (ad bd cd    ae be ce    af bf cf)
            var index1 = initialCombinationLength;
            var combinations = totalCombinations;
            totalCombinations = 0;
            for (var j1 = 0; j1 < chars.Length; j1++)
            for (var i1 = 0; i1 < combinations; i1++)
            {
                sb.Insert(index1, chars[j1]);
                index1 += initialCombinationLength + 1;
                totalCombinations++;
            }
        }

        result = new List<string>(totalCombinations);
        for(var i=0;i<totalCombinations;i++) 
            result.Add(sb.ToString(i * combinationLength, combinationLength));

        return result;
    }
}
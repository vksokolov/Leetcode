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
        var func = () => LongestPalindrome("babad");
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
    public string LongestPalindrome(string s)
    {
        var maxLength = 0;
        var palindromeStartIndex = 0;

        for (var i = 0; i < s.Length;)
        {
            CheckFor(i, i);
            CheckFor(i, ++i);
        }

        void CheckFor(int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            
            left++;
            
            if (right - left > maxLength)
            {
                maxLength = right - left;
                palindromeStartIndex = left;
            }
        }
        
        return s.AsSpan(palindromeStartIndex, maxLength).ToString();
    }
}
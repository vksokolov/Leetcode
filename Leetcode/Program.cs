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
    // Encodes a URL to a shortened URL
    public string encode(string longUrl) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(longUrl);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) 
    {
        var base64EncodedBytes = System.Convert.FromBase64String(shortUrl);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}

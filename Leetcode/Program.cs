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
        var func = () => Interpret("G()(al)");
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
    public string Interpret(string command)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < command.Length;)
        {
            switch (command[i++])
            {
                case 'G':
                    sb.Append('G');
                    break;
                case '(':
                    if (command[i++] == ')')
                        sb.Append('o');
                    else
                    {
                        sb.Append("al");
                        i += 2;
                    }

                    break;
            }
        }

        return sb.ToString();
    }
}
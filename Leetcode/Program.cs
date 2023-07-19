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
        var nums = new int[] { 10, 4, 8, 3 };
        var func = () => LeftRightDifference(nums);
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
    public int[] LeftRightDifference(int[] nums)
    {
        var leftSums = new int[nums.Length];
        leftSums[0] = 0;
        
        var rightSums = new int[nums.Length];
        rightSums[^1] = 0;
        
        var answer = new int[nums.Length];
        int i;

        for (i = 1; i < nums.Length; i++)
        {
            leftSums[i] = nums[i-1] + leftSums[i - 1];
            rightSums[^(i + 1)] = rightSums[^i] + nums[^i];
        }

        for (i = 0; i < nums.Length; i++)
        {
            answer[i] = leftSums[i] - rightSums[i];
            if (answer[i] < 0) answer[i] = -answer[i];
        }

        return answer;
    }
}
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
        var func = () => ThreeSum(new int[]{-1,0,1,2,-1,-4});
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
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        var set = new HashSet<(int i, int j, int k)>();
        var map = new Dictionary<int, List<int>>()
        {
            {nums[0], new List<int> {0}},
        };
        for (var i = 1; i < nums.Length-1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                var negativeSum = -(nums[i] + nums[j]);

                if (map.TryGetValue(negativeSum, out var kIndexes))
                {
                    var entryValues = new [] { nums[i], nums[j], negativeSum };
                    Array.Sort(entryValues);
                    set.Add((entryValues[0], entryValues[1], entryValues[2]));
                }
            }
            
            if (!map.TryGetValue(nums[i], out var indexes))
                map.Add(nums[i], indexes = new List<int> {i});

            indexes.Add(i);
        }

        foreach (var (i, j, k) in set)
            result.Add(new List<int> {i, j, k});
        
        return result;
    }
}
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
    public int DeepestLeavesSum(TreeNode root)
    {
        var map = new Dictionary<int, List<int>>();
        var maxLevel = 0;
        return map[maxLevel].Sum();

        void FillMap(TreeNode node, int level)
        {
            if (node == null) 
                return;
            maxLevel = Math.Max(maxLevel, level);
            map.TryAdd(level, new List<int>());
            map[level].Add(node.val);
            FillMap(node.left, level + 1);
            FillMap(node.right, level + 1);
        }
    }
}
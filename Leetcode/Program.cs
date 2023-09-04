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
        var func = () => GenerateTrees(3);
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
    private const TreeNode NullNode = null;
    public IList<TreeNode> GenerateTrees(int n) => GenerateTrees(1, n);

    public IList<TreeNode> GenerateTrees(int left, int right)
    {
        if (left > right) return new List<TreeNode> { NullNode };

        var result = new List<TreeNode>();
        
        for (var i = left; i <= right; i++)
        {
            //generate left trees
            var leftTrees = GenerateTrees(left, i-1);
            //generate right trees
            var rightTrees = GenerateTrees(i+1, right);

            foreach (var leftTree in leftTrees)
            foreach (var rightTree in rightTrees)
                result.Add(new TreeNode(i, leftTree, rightTree));
        }

        return result;
    }
}
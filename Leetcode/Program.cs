using System;
using System.Collections.Generic;
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
    public int AverageOfSubtree(TreeNode root)
    {
        var count = 0;
        var subTreeSums = new Dictionary<TreeNode, (int Sum, int NodesCount)>();
        CalculateSubTreeSum(root);
        FindAllAvgs(root);
        return count;

        (int Sum, int NodesCount) CalculateSubTreeSum(TreeNode node)
        {
            if (node == null) return (0, 0);
            var left = CalculateSubTreeSum(node.left);
            var right = CalculateSubTreeSum(node.right);
            subTreeSums[node] = (node.val + left.Sum + right.Sum, 1 + left.NodesCount + right.NodesCount);
            return subTreeSums[node];
        }

        void FindAllAvgs(TreeNode node)
        {
            var subValue = subTreeSums[node];
            if (node.val == subValue.Sum/subValue.NodesCount)
                count++;
            
            if (node.left != null)
                FindAllAvgs(node.left);
            
            if (node.right != null)
                FindAllAvgs(node.right);
        }
    }
}
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
        var func = () => IsValidBST(TreeNode.Create(new int?[]{5,1,4,null,null,3,6}));
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
    public bool IsValidBST(TreeNode root)
    {
        return IsValid(root, long.MinValue, long.MaxValue);
        
        bool IsValid(TreeNode node, long min, long max) =>
            min < node.val &&
            node.val < max &&
            (node.left == null || IsValid(node.left, min, node.val)) &&
            (node.right == null || IsValid(node.right, node.val, max));
    }
}
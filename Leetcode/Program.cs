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
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        bool leftCheck;
        bool rightCheck;
        
        if (root == null) 
            return 0;
        
        return GetSum(root);
        
        int GetSum(TreeNode node)
        {
            var sum = 0;

            if (node == null)
                return 0;

            if (low <= node.val && node.val <= high)
                sum += node.val;

            sum += GetSum(node.left);
            sum += GetSum(node.right);

            return sum;
        }
    }
}
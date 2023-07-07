using System;

namespace Leetcode
{
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
        public string GetResult()
        {
            //var root = 0;
            //var targetSum = 0;

            var root = new TreeNode(1, null, new TreeNode(2));
            var targetSum = 1;
            return HasPathSum(root, targetSum).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;
            if (ReferenceEquals(root.left, root.right)) return targetSum == root.val;

            return
                HasPathSum(root.left, targetSum - root.val) || 
                HasPathSum(root.right, targetSum - root.val);
        }
    }
}

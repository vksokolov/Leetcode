using System;

namespace Leetcode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    
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
            return .ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            return IsLeftSymmetricalToRight(root.left, root.right);

            bool IsLeftSymmetricalToRight(TreeNode left, TreeNode right)
            {
                if (left == null) return right == null;
                if (right == null || left.val != right.val) return false;
                return IsLeftSymmetricalToRight(left.left, right.right) &&
                       IsLeftSymmetricalToRight(left.right, right.left);
            }

        }
    }
}

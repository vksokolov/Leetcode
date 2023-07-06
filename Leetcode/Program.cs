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
            var root1 = new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5)));
            var test1 = new Test("3", MaxDepth(root1).ToPrettyString());
            
            var root3 = new TreeNode(1, null, new TreeNode(2));
            var test3 = new Test("2", MaxDepth(root3).ToPrettyString());
            
            var test5 = new Test("0", MaxDepth(null).ToPrettyString());
            
            var root2 = new TreeNode(1);
            var test2 = new Test("1", MaxDepth(root2).ToPrettyString());
            
            var root4 = new TreeNode(1, new TreeNode(2));
            var test4 = new Test("2", MaxDepth(root4).ToPrettyString());
            
            var root6 = new TreeNode(1, new TreeNode(2, new TreeNode(3)), new TreeNode(4, new TreeNode(5, new TreeNode(6, new TreeNode(7)))));
            var test6 = new Test("2", MaxDepth(root4).ToPrettyString());
            
            return $"{test1}\n{test2}\n{test3}\n{test4}\n{test5}";
        }

        class Test
        {
            private readonly string _expected;
            private readonly string _actual;

            public Test(string expected, string actual)
            {
                _expected = expected;
                _actual = actual;
            }

            public override string ToString()
            {
                return $"{(_actual == _expected?"OK":"ERROR")}\t{_actual}, {_expected} expected";
            }
        }
    }

    internal partial class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            return root == null ? 0 : Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
            int Max(int a, int b) => a > b ? a : b;
        }
    }
}

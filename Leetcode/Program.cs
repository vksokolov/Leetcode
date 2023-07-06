using System;
using System.Collections.Generic;

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
        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            FillList(root);
            return list;
            
            void FillList(TreeNode node)
            {
                if (node == null) return;
                
                FillList(node.left);
                list.Add(node.val);
                FillList(node.right);
            }
        }
    }
}

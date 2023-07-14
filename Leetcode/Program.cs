using System;
using System.Diagnostics;
using System.Text;

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
        public const bool Benchmark = false;
        private static Stopwatch _watch = new Stopwatch();

        public string GetResult()
        {
            var func = () => RecoverFromPreorder("1-401--349---90--88");
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
        public TreeNode RecoverFromPreorder(string traversal)
        {
            var nestingLevel = 0;
            var i = 0;
            var head = new TreeNode();
            TreeNode tmpNode;

            FillNode(head);
            return head;

            void FillNode(TreeNode node, int indentLevel = 0)
            {
                while (i < traversal.Length && i != '-')
                    node.val = node.val * 10 + (traversal[i++] - '0');

                for (; i < traversal.Length; i++)
                {
                    var c = traversal[i];
                    if (c == '-')
                    {
                        nestingLevel++;
                    }
                    else
                    {
                        tmpNode = new TreeNode();
                        FillNode(tmpNode, nestingLevel);
                    }
                }
            }
        }
    }
}

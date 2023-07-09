using System;
using System.Diagnostics;

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
            var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            var func = () => ReverseList(list);
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
        public ListNode ReverseList(ListNode h)
        {
            return ReverseRecursively(h);
            
            ListNode ReverseRecursively(ListNode head)
            {
                if (head.next == null) return head;

                var tail = head.next;
                var newHead = ReverseRecursively(tail);

                tail.next = head;
                head.next = null;
                

                return newHead;
            }
        }
    }
}

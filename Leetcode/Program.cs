﻿using System;
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
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;
            var node = head;

            while (node.next != null)
            {
                if (node.next.val == val)
                {
                    if (node.next.next != null)
                    {
                        node.next.val = node.next.next.val;
                        node.next.next = node.next.next.next;
                    }
                    else
                        node.next = null;
                }
                else
                {
                    node = node.next;
                }
            }

            if (head.val == val)
                head = head.next;

            return head;
        }
    }
}

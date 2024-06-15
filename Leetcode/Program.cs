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
        var list = ListNode.Create(new int?[] { 1, 2, 3, 4, 5 });
        var func = () => RemoveNthFromEnd(list, 2);
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
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var tmp = head;
        var stack = new Stack<ListNode>();
        ListNode newHead = null;
        
        while(tmp != null)
        {
            stack.Push(tmp);
            tmp = tmp.next;
        }

        while (stack.TryPop(out var node))
        {
            if (--n == 0)
                continue;

            node.next = newHead;
            newHead = node;
        }
        return newHead;
    }
}
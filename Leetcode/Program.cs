using System;
using System.Collections.Generic;
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
        public class MyStack
        {

            private Queue<int> _q;

            public MyStack()
            {
                _q = new Queue<int>();
            }

            public void Push(int x)
            {
                _q.Enqueue(x);
                
                for (var i = 0; i < _q.Count-1; i++) 
                    _q.Enqueue(_q.Dequeue());
            }

            public int Pop() => 
                _q.Dequeue();

            public int Top() => 
                _q.Peek();

            public bool Empty() => 
                _q.Count == 0;
        }
    }
}

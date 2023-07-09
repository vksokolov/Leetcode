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
            var func = () => IsIsomorphic("foo", "bar");
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
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;
            
            var map = new Dictionary<char, int>();

            var a = GetValue(s);
            var b = GetValue(t);

            for (var i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i]) return false;
            }

            return true;
            
            List<int> GetValue(string s)
            {
                var val = new List<int>(s.Length);
                map.Clear();
                foreach (var c in s)
                {
                    if (!map.TryGetValue(c, out var i)) 
                        map.Add(c, map.Count);
                    
                    val.Add(map[c]);
                }

                return val;
            }
        }
    }
}

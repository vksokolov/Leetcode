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
            var func = () => IsIsomorphic("fos", "baa");
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
            
            var map = new Dictionary<int, int>(s.Length);

            for (var i = 0; i < s.Length; i++)
            {
                if (!map.TryGetValue(s[i], out var cS) && !map.TryGetValue(-t[i], out var cT))
                {
                    if (cS != cT) return false;
                    
                    map[s[i]] = t[i];
                    map[-t[i]] = s[i];
                }
                else if (t[i] != cS) return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;

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
        public string GetResult()
        {
            return ClimbStairs(3).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public int ClimbStairs(int n)
        {
            Dictionary<int, int> cache = new Dictionary<int, int>(n - 1);

            return f(n);

            int f(int stairs)
            {
                if (stairs == 1) return 1;

                if (!cache.TryGetValue(stairs, out var cachedVariants))
                {
                    if (stairs > 2)
                        cachedVariants = f(stairs - 2) + f(stairs - 1);
                    else cachedVariants = f(stairs - 1)+1;
                    cache.Add(stairs, cachedVariants);
                }

                return cachedVariants;
            }
        }
    }
}

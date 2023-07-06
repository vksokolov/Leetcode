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
            return LengthOfLongestSubstring("abba").ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            
            var set = new Dictionary<char, int>();
            var leftIndex = 0;
            var maxLen = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (set.TryGetValue(s[i], out var index))
                {
                    if (i - leftIndex > maxLen) maxLen = i - leftIndex;
                    if (index + 1 > leftIndex) leftIndex = index + 1;
                }
                set[s[i]] = i;
            }

            if (s.Length - leftIndex > maxLen) maxLen = s.Length - leftIndex;
            return maxLen;
        }
    }
}

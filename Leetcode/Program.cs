using System;
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
        public string GetResult()
        {
            string[] strs = { "flower", "flow", "flight" };
            return LongestCommonPrefix(strs);
        }
    }

    internal partial class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            var result = new StringBuilder("");
            var charIndex = 0;
            var maxIndex = int.MaxValue;
            var strCount = strs.Length;

            foreach (var str in strs)
                if (str.Length < maxIndex)
                    maxIndex = str.Length;

            for (var i = 0; i < maxIndex; i++)
            {
                var firstStrChar = strs[0][charIndex];
                for (var strIndex = 1; strIndex < strCount; strIndex++)
                {
                    var str = strs[strIndex];
                    if (str[charIndex] != firstStrChar) return result.ToString();
                }

                charIndex++;
                result.Append(firstStrChar);
            }

            return result.ToString();
        }
    }
}

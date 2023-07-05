using System;

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
            var str = "   fly me   to   the moon  ";
            return LengthOfLastWord(str).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public int LengthOfLastWord(string s)
        {
            var wLen = 0;
            for(int i=s.Length-1;i>=0;i--)
                if (s[i] == ' ')
                {
                    if (wLen != 0) return wLen;
                }
                else
                    wLen++;

            return wLen;
        }
    }
}

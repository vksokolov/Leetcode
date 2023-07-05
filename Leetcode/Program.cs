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
            return AddBinary("1010", "1011").ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public string AddBinary(string a, string b)
        {
            if (a.Length < b.Length) (a, b) = (b, a);
            
            var sb = new StringBuilder();
            var buffer = 0;
            
            for (int i = 1; i <= a.Length; i++)
            {
                int aC = a[^i] - '0';
                int bC = b.Length >= i ? b[^i] - '0' : 0;
                buffer += aC + bC;
                if (buffer < 2)
                {
                    sb.Insert(0, (char)('0' + buffer));
                    buffer = 0;
                }
                else
                {
                    sb.Insert(0, (char)('0' + (buffer-2)));
                    buffer = 1;
                }
            }
            
            if (buffer > 0)
                sb.Insert(0, (char)('0' + buffer));

            return sb.ToString();
        }
    }
}

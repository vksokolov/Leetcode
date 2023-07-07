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
            return Generate(5).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public IList<int> Generate(int rowIndex)
        {
            var curList = new List<int>(1){1};
            var prevList = curList;
            for (var i = 1; i <= rowIndex; i++)
            {
                curList = new List<int>(i+1){1};
                
                for (var j = 0; j < i-1; j++) curList.Add(prevList[j] + prevList[j + 1]);
                
                curList.Add(1);
                prevList = curList;
            }

            return curList;
        }
    }
}

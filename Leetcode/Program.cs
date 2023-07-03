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
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            return RemoveDuplicates(nums).ToString();
        }
    }

    internal partial class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            
            var index = 1;
            var prevAddedValue = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                if (prevAddedValue != nums[i])
                {
                    nums[index] = nums[i];
                    prevAddedValue = nums[i];
                    index++;
                }
            }

            return index;
        }
    }
}

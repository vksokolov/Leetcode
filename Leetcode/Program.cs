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
            int[] arr = { 1, 3, 5 };
            return SearchInsert(arr, 4).ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public int SearchInsert(int[] nums, int target) {
            var leftBound = 0;
            var l = nums.Length;
            var rightBound = l;

            while (leftBound < rightBound)
            {
                int i = (leftBound + rightBound) / 2;

                if (nums[i] == target) return i;

                if (nums[i] < target)
                {
                    if (i == l-1) return l;

                    if (target < nums[i + 1]) return i + 1;

                    leftBound = i + 1;
                }
                else
                {
                    if (i == 0) return 0;

                    if (nums[i - 1] < target) return i;

                    rightBound = i;
                }
            }

            return nums.Length;
        }
    }
}

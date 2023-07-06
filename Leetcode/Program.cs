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
            int[] nums1 = { 4,5,6,0,0,0 };
            int[] nums2 = { 1,2,3 };
            int m = 3;
            int n = 3;
            Merge(nums1, m, nums2, n);
            return nums1.ToPrettyString();
        }
    }

    internal partial class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) return;
            if (m == 0)
            {
                for (var i = 0; i < nums2.Length; i++)
                    nums1[i] = nums2[i];

                return;
            }


            var lastEmptySlotIndex = nums1.Length - 1;
            var lastCheckedIndex = m - 1;
            for (var i = 1; i <= nums2.Length;)
            {
                if (lastCheckedIndex < 0)
                {
                    nums1[^(i+m)] = nums2[^i];
                    i++;
                    continue;
                }
                
                if (nums1[lastCheckedIndex] < nums2[^i])
                {
                    nums1[lastEmptySlotIndex] = nums2[^i];
                    i++;
                }
                else
                {
                    nums1[lastEmptySlotIndex] = nums1[lastCheckedIndex];
                    nums1[lastCheckedIndex] = 0;
                    lastCheckedIndex--;
                }

                lastEmptySlotIndex--;
            }
        }
    }
}

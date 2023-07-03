using System;

namespace Leetcode;

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
        int[] nums = { 3,2,2,3 };
        //int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
        //int[] nums = { 1 };
        //int[] nums = { 3, 3 };
        var val = 3;
        return RemoveElement(nums, val).ToPrettyString();
    }
}

internal partial class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        var cur = 0;
        for (var i = 0; i < nums.Length;)
        {
            if (nums[i++] == val) continue;
            
            nums[cur++] = nums[i-1];
        }
        return cur;
    }
}
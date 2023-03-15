using System.Collections.Generic;

class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var sub = target - nums[i];
            if (dict.TryGetValue(sub, out var index))
                return new int[] { i, index };
            
            dict[nums[i]] = i;
        }

        return null;
    }
}
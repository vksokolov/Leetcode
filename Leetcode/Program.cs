using System;

class Program
{
    public static void Main()
    {
        Solution s = new Solution();
        Print(s.GetResult());
    }

    public static void Print(string msg)
    {
        Console.WriteLine(msg);
    }
}
class Solution
{
    public string GetResult()
    {
        return IsPalindrome(1000021).ToString();
    }
    
    public bool IsPalindrome(int x)
    {
        if (x == 0) return true;
        if (x < 0) return false;

        var xStr = x.ToString();
        for (int a = 0, b = xStr.Length - 1; a < b; a++, b--)
            if (xStr[a] != xStr[b]) return false;

        return true;
    }
}
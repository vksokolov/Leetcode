using System;
using System.Collections.Generic;
using System.Diagnostics;

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
    public const bool Benchmark = false;
    private static Stopwatch _watch = new Stopwatch();

    public string GetResult()
    {
        var func = () => GetRow(4);
        if (Benchmark)
        {
            int iterations = 9999999;
            _watch.Start();

            for (int i = 0; i < iterations; i++)
                func();

            _watch.Stop();
            return func().ToPrettyString() + $"\n{iterations} iterations, {_watch.ElapsedMilliseconds} ms";
        }

        var result = func();
        return result.ToPrettyString();
    }
}

internal partial class Solution
{
    public class ParkingSystem
    {
        private Dictionary<int, int> _carTypeToSlots;
        public ParkingSystem(int big, int medium, int small)
        {
            _carTypeToSlots = new Dictionary<int, int>()
            {
                { 1, big },
                { 2, medium },
                { 3, small }
            };
        }

        public bool AddCar(int carType) => 
            _carTypeToSlots[carType]-- > 0;
    }
}
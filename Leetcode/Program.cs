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
    public class SubrectangleQueries
    {
        private int[][] _rectangle;
        private List<RectQuery> _queries = new();
        
        public SubrectangleQueries(int[][] rectangle)
        {
            _rectangle = rectangle;
        }

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            _queries.Add(new RectQuery(row1, col1, row2, col2, newValue));
        }

        public int GetValue(int row, int col)
        {
            RectQuery lastQuery = null;
            foreach (var query in _queries)
            {
                if (query.IsInside(row, col))
                    lastQuery = query;
            }

            return lastQuery?.Value ?? _rectangle[row][col];
        }

        private class RectQuery
        {
            public readonly (int x, int y) Start;
            public readonly (int x, int y) End;
            public readonly int Value;

            public RectQuery(int row1, int col1, int row2, int col2, int value)
            {
                Start.x = row1;
                Start.y = col1;
                End.x = row2;
                End.y = col2;
                Value = value;
            }
            
            public bool IsInside(int row, int col) => 
                row >= Start.x && row <= End.x && col >= Start.y && col <= End.y;
        }
    }
}
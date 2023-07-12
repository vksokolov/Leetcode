using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
        public const bool Benchmark = false;
        private static Stopwatch _watch = new Stopwatch();

        public string GetResult()
        {
            var func = () => EqualFrequency("bac");
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
        public bool EqualFrequency(string word)
        {
            var charFrequency = new Dictionary<char, byte>();
            var frequencyFrequency = new Dictionary<byte, byte>();
            
            foreach (var c in word)
                if (!charFrequency.TryAdd(c, 1))
                    charFrequency[c]++;

            foreach (var (_, val) in charFrequency)
                if (!frequencyFrequency.TryAdd(val, 1))
                    frequencyFrequency[val]++;

            return
                AllCharsAreUniqueOrSame() ||
                frequencyFrequency.Count == 2 &&
                (HasSingleEntryOfSingleChar() || CanEqualizeByRemovingTheMostFrequentChar());

            bool AllCharsAreUniqueOrSame()
            {
                if (frequencyFrequency.Count != 1) return false;

                using var enumerator = frequencyFrequency.GetEnumerator();
                enumerator.MoveNext();
                return enumerator.Current.Key == 1 || enumerator.Current.Value == 1;
            }

            bool HasSingleEntryOfSingleChar() => 
                frequencyFrequency.TryGetValue(1, out var amount) && amount == 1;

            bool CanEqualizeByRemovingTheMostFrequentChar()
            {
                (byte EntryLength, byte Entries) max = (0,0);
                (byte EntryLength, byte Entries) min = (byte.MaxValue,byte.MaxValue);
                foreach (var (entryLength, entries) in frequencyFrequency)
                {
                    if (entryLength > max.EntryLength) 
                        max = (entryLength, entries);
                    
                    if (entryLength < min.EntryLength) 
                        min = (entryLength, entries);
                }

                return max.Entries == 1 && max.EntryLength - min.EntryLength == 1;
            }
        }
    }
}

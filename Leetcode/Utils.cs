using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode;

public static class Utils
{
    private static readonly StringBuilder Sb = new();

    public static string ToPrettyString<T>(this T[] arr)
    {
        Sb.Clear();
        Sb.Append('[');
        for (var index = 0; index < arr.Length; index++)
        {
            var n = arr[index];
            if (index != 0)
                Sb.Append(", ");

            Sb.Append(n);
        }

        Sb.Append(']');
        return Sb.ToString();
    }

    public static string ToPrettyString<T>(this IEnumerable<T> list)
    {
        var arr = list.ToArray();
        return arr.ToPrettyString();
    }

    public static string ToPrettyString<T>(this T i)
        => i.ToString();
}
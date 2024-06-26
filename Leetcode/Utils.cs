﻿using System;
using System.Collections;
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

            Sb.Append(n.ToPrettyString());
        }

        Sb.Append(']');
        return Sb.ToString();
    }
    
    public static string ToPrettyString(this IEnumerable list)
    {
        if (list == null)
            return "null";

        var stringBuilder = new StringBuilder("[");
        var enumerable = list as object[] ?? list.Cast<object>().ToArray();
        foreach (var item in enumerable)
        {
            if (item is IEnumerable subList)
                stringBuilder.Append(subList.Cast<object>().ToPrettyString());
            else
                stringBuilder.Append(item);

            stringBuilder.Append(',');
            stringBuilder.Append(' ');
        }

        // Remove trailing comma
        if (enumerable.Any())
            stringBuilder.Length-=2;

        stringBuilder.Append(']');
        return stringBuilder.ToString();
    }

    public static string ToPrettyString<T>(this T i)
    {
        if (i is IEnumerable subList)
            return subList.ToPrettyString();
        
        return i.ToString();
    }

    public static T[][] To2dArray<T>(this string s)
    {
        var rows = s.Split("],");
        var result = new T[rows.Length][];

        for (var i = 0; i < rows.Length; i++)
        {
            var row = rows[i].Trim();
            row = row.Trim('[', ']');
            var cols = row.Split(',');
            result[i] = new T[cols.Length];

            for (var j = 0; j < cols.Length; j++)
            {
                var col = cols[j].Trim();
                result[i][j] = (T) Convert.ChangeType(col, typeof(T));
            }
        }

        return result;
    }
}
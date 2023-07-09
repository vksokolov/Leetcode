using System;

namespace Leetcode;

public static class BinaryExt
{
    public static string ToBinary(this uint number, int bitsLength = 32) => 
        ToBinary((int)number);

    public static string ToBinary(this int number, int bitsLength = 32) => 
        NumberToBinary(number, bitsLength);

    public static string NumberToBinary(int number, int bitsLength = 32) => 
        Convert.ToString(number, 2).PadLeft(bitsLength, '0');

    public static int FromBinaryToInt(this string binary) => 
        BinaryToInt(binary);

    public static int BinaryToInt(string binary) => 
        Convert.ToInt32(binary, 2);
}

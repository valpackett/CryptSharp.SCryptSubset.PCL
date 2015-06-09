﻿#region License
/*
CryptSharp
Copyright (c) 2013 James F. Bellinger <http://www.zer7.com/software/cryptsharp>

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/
#endregion

namespace CryptSharp.SCryptSubset.PCL
{
    static class BitMath
    {
        public static int CountLeadingZeros(int value)
        {
            int count;
            for (count = 0; count < 32 && 0 == (value & (0x80000000 >> count)); count++) ;
            return count;
        }

        public static bool IsPositivePowerOf2(int value)
        {
            return 0 < value && 0 == (value & (value - 1));
        }

        public static byte ReverseBits(byte value)
        {
            byte reversed = (byte)((((ulong)value * 0x80200802) & 0x884422110) * 0x101010101 >> 32);
            return reversed;
        }

        public static byte ShiftLeft(byte value, int bits)
        {
            return (byte)(bits > 0 ? value << bits : value >> (-bits));
        }

        public static byte ShiftRight(byte value, int bits)
        {
            return ShiftLeft(value, -bits);
        }

        public static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = right;
            right = left;
            left = temp;
        }
    }
}

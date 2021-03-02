using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Redskap
{
    internal static class FormattingHelpers
    {
        /// <summary>
        /// Writes a value [ 00 .. 99 ] to the buffer starting at the specified offset.
        /// This method performs best when the starting index is a constant literal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void WriteTwoDecimalDigits(uint value, Span<byte> destination, int offset)
        {
            Debug.Assert(value <= 99);

            var temp = '0' + value;
            value /= 10;
            destination[offset + 1] = (byte)(temp - (value * 10));

            destination[offset] = (byte)('0' + value);
        }

        /// <summary>
        /// Writes a value [ 000 .. 999 ] to the buffer starting at the specified offset.
        /// This method performs best when the starting index is a constant literal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteThreeDecimalDigits(uint value, Span<byte> buffer, int startingIndex = 0)
        {
            Debug.Assert(value <= 999);

            var temp = '0' + value;
            value /= 10;
            buffer[startingIndex + 2] = (byte)(temp - (value * 10));

            temp = '0' + value;
            value /= 10;
            buffer[startingIndex + 1] = (byte)(temp - (value * 10));

            buffer[startingIndex] = (byte)('0' + value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLVParsing
{
    internal static class TlvExtensions
    {
        internal static byte[] HexStringToByteArray(this string hexStr)
        {
            return Enumerable
                .Range(0, hexStr.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexStr.Substring(x, 2), 16))
                .ToArray();
        }

        internal static string ByteArrayToHexString(this byte[] byteArr)
        {
            var sb = new StringBuilder(byteArr.Length * 2);
            foreach (byte b in byteArr)
            {
                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }

        internal static byte[] AsciiStringToByteArray(this string asciiStr)
        {
            return Encoding.ASCII.GetBytes(asciiStr);
        }

        internal static string ByteArrayToAsciiString(this byte[] byteArr)
        {
            return Encoding.ASCII.GetString(byteArr);
        }

        internal static int ByteArrayToInt(this byte[] data)
        {
            var result = 0;
            for (var i = 0; i < data.Length; i++)
            {
                result = (result << 8) | data[i];
            }

            return result;
        }

        public static bool IsMultiByteLength(this byte v) => (v & 0x80) != 0;

        public static bool IsLastTagByte(this byte v) => (v & 0x80) == 0;

        public static bool IsMultiByteTag(this byte v) => (v & 0x1F) == 0x1F;

        public static bool IsConstructedTag(this byte v) => (v & 0x20) != 0;

        public static bool IsNullByte(this byte v) => v == 0x00;
    }
}
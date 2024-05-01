using System.Text;

namespace Corset.Tests.HelperFunctions
{
    /// <summary>
    /// Extension methods for helper functions.
    /// </summary>
    public static class HelperExtensions
    {
        /// <summary>
        /// Converts a string to a byte array using the specified encoding.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <param name="encodingUsing">
        /// The encoding to use. If not specified, UTF-8 encoding will be used.
        /// </param>
        /// <returns>The byte array representation of the string.</returns>
        public static byte[] ToByteArray(this string? input, Encoding? encodingUsing = null)
        {
            encodingUsing ??= Encoding.UTF8;
            return string.IsNullOrEmpty(input) ? System.Array.Empty<byte>() : encodingUsing.GetBytes(input);
        }

        /// <summary>
        /// Converts a byte array to a string using the specified encoding, starting from the
        /// specified index and with the specified count of bytes.
        /// </summary>
        /// <param name="input">The byte array to convert.</param>
        /// <param name="encodingUsing">The encoding to use.</param>
        /// <param name="index">The starting index of the byte array. Defaults to 0.</param>
        /// <param name="count">
        /// The number of bytes to convert. Defaults to -1, which converts all remaining bytes.
        /// </param>
        /// <returns>The string representation of the byte array.</returns>
        public static string ToString(this byte[]? input, Encoding? encodingUsing, int index = 0, int count = -1)
        {
            if (input == null)
                return "";
            if (count == -1)
                count = input.Length - index;
            encodingUsing ??= Encoding.UTF8;
            return encodingUsing.GetString(input, index, count);
        }
    }
}
using System.Text;

namespace Corset.Tests.HelperFunctions
{
    public static class HelperExtensions
    {
        public static byte[] ToByteArray(this string input, Encoding encodingUsing = null)
        {
            encodingUsing ??= Encoding.UTF8;
            return string.IsNullOrEmpty(input) ? System.Array.Empty<byte>() : encodingUsing.GetBytes(input);
        }

        public static string ToString(this byte[] input, Encoding encodingUsing, int index = 0, int count = -1)
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
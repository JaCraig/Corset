/*
Copyright 2016 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Corset.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Text;

namespace Corset
{
    /// <summary>
    /// Extension methods dealing with compression
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class CompressionExtensions
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        private static IServiceProvider? ServiceProvider
        {
            get
            {
                if (_ServiceProvider is not null)
                    return _ServiceProvider;
                lock (ServiceProviderLock)
                {
                    if (_ServiceProvider is not null)
                        return _ServiceProvider;
                    _ServiceProvider = new ServiceCollection().AddCanisterModules()?.BuildServiceProvider();
                }
                return _ServiceProvider;
            }
        }

        /// <summary>
        /// The service provider lock
        /// </summary>
        private static readonly object ServiceProviderLock = new object();

        /// <summary>
        /// The service provider
        /// </summary>
        private static IServiceProvider? _ServiceProvider;

        /// <summary>
        /// Compresses the data using the specified compression type
        /// </summary>
        /// <param name="data">Data to compress</param>
        /// <param name="compressorType">Compression type</param>
        /// <returns>The compressed data</returns>
        public static byte[]? Compress(this byte[]? data, CompressorType? compressorType = null)
        {
            if (data is null)
                return data;
            compressorType ??= CompressorType.Deflate;
            return ServiceProvider?.GetService<Corset>()?.Compress(data, compressorType);
        }

        /// <summary>
        /// Compresses a string of data
        /// </summary>
        /// <param name="data">Data to Compress</param>
        /// <param name="encodingUsing">Encoding that the data uses (defaults to UTF8)</param>
        /// <param name="compressorType">The compression type used</param>
        /// <returns>The data Compressed</returns>
        public static string? Compress(this string? data, Encoding? encodingUsing = null, CompressorType? compressorType = null)
        {
            if (data is null)
                return data;
            compressorType ??= CompressorType.Deflate;
            encodingUsing ??= Encoding.UTF8;
            return Convert.ToBase64String(ToByteArray(data, encodingUsing).Compress(compressorType) ?? Array.Empty<byte>());
        }

        /// <summary>
        /// Compresses the data using the specified compression type
        /// </summary>
        /// <param name="data">Data to compress</param>
        /// <param name="compressorType">Compression type</param>
        /// <returns>The compressed data</returns>
        public static byte[]? Compress(this byte[]? data, string compressorType) => data.Compress((CompressorType)compressorType);

        /// <summary>
        /// Compresses a string of data
        /// </summary>
        /// <param name="data">Data to Compress</param>
        /// <param name="encodingUsing">Encoding that the data uses (defaults to UTF8)</param>
        /// <param name="compressorType">The compression type used</param>
        /// <returns>The data Compressed</returns>
        public static string? Compress(this string? data, Encoding? encodingUsing, string compressorType) => data.Compress(encodingUsing, (CompressorType)compressorType);

        /// <summary>
        /// Decompresses the byte array that is sent in
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <param name="compressorType">The compression type used</param>
        /// <returns>The data decompressed</returns>
        public static byte[]? Decompress(this byte[]? data, CompressorType? compressorType = null)
        {
            if (data is null)
                return data;
            compressorType ??= CompressorType.Deflate;
            return ServiceProvider?.GetService<Corset>()?.Decompress(data, compressorType);
        }

        /// <summary>
        /// Decompresses a string of data
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <param name="encodingUsing">Encoding that the result should use (defaults to UTF8)</param>
        /// <param name="compressorType">The compression type used</param>
        /// <returns>The data decompressed</returns>
        public static string? Decompress(this string? data, Encoding? encodingUsing = null, CompressorType? compressorType = null)
        {
            if (data is null)
                return data;
            compressorType ??= CompressorType.Deflate;
            encodingUsing ??= Encoding.UTF8;
            byte[]? TempArray = Convert.FromBase64String(data);
            TempArray = TempArray.Decompress(compressorType);
            if (TempArray is null)
                return null;
            return encodingUsing.GetString(TempArray, 0, TempArray.Length);
        }

        /// <summary>
        /// Decompresses the byte array that is sent in
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <param name="compressorType">The compression type used</param>
        /// <returns>The data decompressed</returns>
        public static byte[]? Decompress(this byte[]? data, string compressorType) => data.Decompress((CompressorType)compressorType);

        /// <summary>
        /// Decompresses a string of data
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <param name="encodingUsing">Encoding that the result should use (defaults to UTF8)</param>
        /// <param name="compressorType">The compression type used</param>
        /// <returns>The data decompressed</returns>
        public static string? Decompress(this string? data, Encoding? encodingUsing, string compressorType) => data.Decompress(encodingUsing, (CompressorType)compressorType);

        /// <summary>
        /// Converts a string to a byte array
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="encodingUsing">The type of encoding the string is using (defaults to UTF8)</param>
        /// <returns>the byte array representing the string</returns>
        private static byte[] ToByteArray(string input, Encoding? encodingUsing = null)
        {
            encodingUsing ??= Encoding.UTF8;
            return string.IsNullOrEmpty(input) ? Array.Empty<byte>() : encodingUsing.GetBytes(input);
        }
    }
}
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

using Corset.Interfaces;
using System;
using System.IO;
using System.IO.Compression;

namespace Corset.BaseClasses
{
    /// <summary>
    /// Compressor base class
    /// </summary>
    public abstract class CompressorBase : ICompressor
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected CompressorBase()
        {
        }

        /// <summary>
        /// Compressor name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Compresses the byte array
        /// </summary>
        /// <param name="data">Data to compress</param>
        /// <returns>Compressed data</returns>
        public byte[] Compress(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            using var Stream = new MemoryStream();
            using var ZipStream = GetStream(Stream, CompressionMode.Compress);
            if (ZipStream == null)
                return Array.Empty<byte>();
            ZipStream.Write(data, 0, data.Length);
            ZipStream.Flush();
            return Stream.ToArray();
        }

        /// <summary>
        /// Decompresses the data
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <returns>The decompressed data</returns>
        public byte[] Decompress(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            using var Stream = new MemoryStream();
            using var DataStream = new MemoryStream(data);
            using var ZipStream = GetStream(DataStream, CompressionMode.Decompress);
            if (ZipStream == null)
                return Array.Empty<byte>();
            var Buffer = new byte[4096];
            while (true)
            {
                var Size = ZipStream.Read(Buffer, 0, Buffer.Length);
                if (Size > 0) Stream.Write(Buffer, 0, Size);
                else break;
            }
            return Stream.ToArray();
        }

        /// <summary>
        /// Gets the stream used to compress/decompress the data
        /// </summary>
        /// <param name="stream">Memory stream used</param>
        /// <param name="compressionMode">Compression mode</param>
        /// <returns>The stream used to compress/decompress the data</returns>
        protected abstract Stream GetStream(MemoryStream stream, CompressionMode compressionMode);
    }
}
﻿/*
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
using Corset.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corset
{
    /// <summary>
    /// Main class used to interact with the compression system
    /// </summary>
    public class Corset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Corset"/> class.
        /// </summary>
        /// <param name="compressors">The compressors.</param>
        public Corset(IEnumerable<ICompressor>? compressors)
        {
            compressors ??= new List<ICompressor>();
            Compressors = new Dictionary<string, ICompressor>();
            foreach (ICompressor Compressor in compressors)
            {
                Compressors.Add(Compressor.Name, Compressor);
            }
        }

        /// <summary>
        /// Gets or sets the compressors.
        /// </summary>
        /// <value>The compressors.</value>
        public IDictionary<string, ICompressor> Compressors { get; }

        /// <summary>
        /// Tostring lock object
        /// </summary>
        private readonly object _ToStringValueLock = new();

        /// <summary>
        /// Tostring value
        /// </summary>
        private string _ToStringValue = "";

        /// <summary>
        /// Compresses the data
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="compressor">The compressor.</param>
        /// <returns>The compressed data</returns>
        public byte[]? Compress(byte[]? data, CompressorType? compressor)
        {
            if (data is null)
                return data;
            compressor ??= CompressorType.Deflate;
            var Key = compressor ?? "";
            return Compressors.ContainsKey(Key) ? Compressors[Key].Compress(data) : data;
        }

        /// <summary>
        /// Decompresses the data
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <param name="compressor">Compressor name</param>
        /// <returns>The decompressed data</returns>
        public byte[]? Decompress(byte[]? data, CompressorType? compressor)
        {
            if (data is null)
                return data;
            compressor ??= CompressorType.Deflate;
            var Key = compressor ?? "";
            return Compressors.ContainsKey(Key) ? Compressors[Key].Decompress(data) : data;
        }

        /// <summary>
        /// String info for the manager
        /// </summary>
        /// <returns>The string info that the manager contains</returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(_ToStringValue))
                return _ToStringValue;
            lock (_ToStringValueLock)
            {
                if (!string.IsNullOrEmpty(_ToStringValue))
                    return _ToStringValue;
                var Builder = new StringBuilder();
                _ = Builder.Append("Compressors: ");
                var Separator = "";
                foreach (var Key in Compressors.Keys.OrderBy(x => x))
                {
                    _ = Builder.AppendFormat("{0}{1}", Separator, Key);
                    Separator = ",";
                }
                _ToStringValue = Builder.ToString();
            }

            return _ToStringValue;
        }
    }
}
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

using Corset.BaseClasses;
using System.IO;
using System.IO.Compression;

namespace Corset.Default
{
    /// <summary>
    /// Deflate compressor
    /// </summary>
    public class DeflateCompressor : CompressorBase
    {
        /// <summary>
        /// Name
        /// </summary>
        public override string Name => "Deflate";

        /// <summary>
        /// Gets the stream
        /// </summary>
        /// <param name="stream">Memory stream</param>
        /// <param name="compressionMode">Compression mode</param>
        /// <returns>The compressor stream</returns>
        protected override Stream GetStream(MemoryStream stream, CompressionMode compressionMode) => new DeflateStream(stream, compressionMode, true);
    }
}
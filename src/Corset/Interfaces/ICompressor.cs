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

namespace Corset.Interfaces
{
    /// <summary>
    /// Compressor interface
    /// </summary>
    public interface ICompressor
    {
        /// <summary>
        /// Compressor name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Compresses the data
        /// </summary>
        /// <param name="data">Data to compress</param>
        /// <returns>Compressed data</returns>
        byte[] Compress(byte[] data);

        /// <summary>
        /// Decompresses the data
        /// </summary>
        /// <param name="data">Data to decompress</param>
        /// <returns>The decompressed data</returns>
        byte[] Decompress(byte[] data);
    }
}
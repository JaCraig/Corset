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

namespace Corset.Enums
{
    /// <summary>
    /// Defines the compressor types in an enum like static class
    /// </summary>
    public class CompressorType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompressorType"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected CompressorType(string? name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the deflate compressor type.
        /// </summary>
        /// <value>The deflate compressor type.</value>
        public static CompressorType Deflate => new("Deflate");

        /// <summary>
        /// Gets the GZip compressor type.
        /// </summary>
        /// <value>The GZip compressor type.</value>
        public static CompressorType GZip => new("GZip");

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        private string? Name { get; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="CompressorType"/>.
        /// </summary>
        /// <param name="compressorType">Type of the compressor.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator CompressorType(string? compressorType) => new(compressorType);

        /// <summary>
        /// Performs an explicit conversion from <see cref="CompressorType"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="compressorType">Type of the compressor.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(CompressorType compressorType) => compressorType.ToString();

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString() => Name ?? "";
    }
}
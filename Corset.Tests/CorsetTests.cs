using Corset.Default;
using Corset.Enums;
using Corset.Interfaces;
using Corset.Tests.BaseClasses;
using Corset.Tests.HelperFunctions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Corset.Tests
{
    public class CorsetTests : TestBaseClass<Corset>
    {
        public CorsetTests()
        {
            _Compressors = new ICompressor[] { new DeflateCompressor(), new GZipCompressor() };
            _TestClass = new Corset(_Compressors);
        }

        private readonly IEnumerable<ICompressor> _Compressors;
        private readonly Corset _TestClass;

        [Fact]
        public void CanCallCompress()
        {
            // Arrange
            var Data = new byte[] { 165, 81, 245, 200 };
            CompressorType Compressor = CompressorType.Deflate;

            // Act
            var Result = _TestClass.Compress(Data, Compressor);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Fact]
        public void CanCallCompressWithNullCompressor() => _ = _TestClass.Compress(new byte[] { 126, 177, 28, 56 }, default);

        [Fact]
        public void CanCallCompressWithNullData() => _ = _TestClass.Compress(default, CompressorType.Deflate);

        [Fact]
        public void CanCallDecompress()
        {
            // Arrange
            CompressorType Compressor = CompressorType.Deflate;
            var Data = _TestClass.Compress("Test data".ToByteArray(), Compressor);

            // Act
            var Result = _TestClass.Decompress(Data, Compressor);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Fact]
        public void CanCallDecompressWithNullCompressor()
        {
            // Arrange
            var Data = _TestClass.Compress("Test data".ToByteArray(), default);

            // Act
            _ = _TestClass.Decompress(Data, default);
        }

        [Fact]
        public void CanCallDecompressWithNullData() => _ = _TestClass.Decompress(default, CompressorType.Deflate);

        [Fact]
        public void CanCallToString()
        {
            // Act
            var Result = _TestClass.ToString();

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.Equal("Compressors: Deflate,GZip", Result);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var Instance = new Corset(_Compressors);

            // Assert
            Assert.NotNull(Instance);
        }

        [Fact]
        public void CanConstructWithNullCompressors() => _ = new Corset(default);

        [Fact]
        public void Compress_ShouldReturnCompressedData()
        {
            // Arrange
            var TestObject = new Corset(new ICompressor[] { new DeflateCompressor(), new GZipCompressor() });
            const string Data = "This is a bit of data that I want to compress";

            // Act
            var CompressedData = TestObject.Compress(Data.ToByteArray(), CompressorType.Deflate);

            // Assert
            Assert.Contains(Convert.ToBase64String(CompressedData ?? Array.Empty<byte>()), new string[] { "CsnILFbILFZIVEjKLFHIT1NISSxJVCjJSCxR8FQoT8wrUSjJV0jOzy0oSi0uBgAAAP//", "CsnILFYAokSFpMwShfw0hZTEkkSFkozEEgVPhfLEvBKFknyF5PzcgqLU4mIAAAAA//8=" });
        }

        [Fact]
        public void CompressorsIsInitializedCorrectly() => Assert.Equal(_Compressors, _TestClass.Compressors.Values);

        [Fact]
        public void Creation_ShouldInitializeCorsetObject()
        {
            // Arrange
            var TestObject = new Corset(new ICompressor[] { new DeflateCompressor(), new GZipCompressor() });

            // Assert
            Assert.NotNull(TestObject);
            Assert.Equal(2, TestObject.Compressors.Count);
        }

        [Fact]
        public void Decompress_ShouldReturnDecompressedData()
        {
            // Arrange
            var TestObject = new Corset(new ICompressor[] { new DeflateCompressor(), new GZipCompressor() });
            const string Data = "This is a bit of data that I want to compress";
            var CompressedData = TestObject.Compress(Data.ToByteArray(), CompressorType.Deflate);

            // Act
            var DecompressedData = TestObject.Decompress(CompressedData, CompressorType.Deflate);

            // Assert
            Assert.Equal(Data, DecompressedData?.ToString(null));
        }
    }
}
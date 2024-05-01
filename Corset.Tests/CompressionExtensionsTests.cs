using BigBook;
using Corset.Enums;
using Corset.Tests.BaseClasses;
using System;
using System.Text;
using Xunit;

namespace Corset.Tests
{
    public class CompressionExtensionsTests : TestBaseClass
    {
        protected override Type ObjectType { get; set; } = typeof(CompressionExtensions);

        [Fact]
        public static void CanCallCompressWithArrayOfByteAndCompressorType()
        {
            // Arrange
            var Data = new byte[] { 206, 217, 116, 215 };
            CompressorType CompressorType = CompressorType.Deflate;

            // Act
            var Result = Data.Compress(CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Fact]
        public static void CanCallCompressWithArrayOfByteAndString()
        {
            // Arrange
            var Data = new byte[] { 154, 185, 14, 48 };
            const string CompressorType = "TestValue2028962735";

            // Act
            var Result = Data.Compress(CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.Equal(Data, Result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallCompressWithArrayOfByteAndStringWithInvalidCompressorType(string? value) => new byte[] { 125, 138, 248, 26 }.Compress(value);

        [Fact]
        public static void CanCallCompressWithStringAndEncodingAndCompressorType()
        {
            // Arrange
            const string Data = "TestValue908613201";
            Encoding EncodingUsing = Encoding.UTF8;
            CompressorType CompressorType = CompressorType.Deflate;

            // Act
            var Result = Data.Compress(EncodingUsing, CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallCompressWithStringAndEncodingAndCompressorTypeWithInvalidData(string value) => value.Compress(Encoding.UTF8, CompressorType.Deflate);

        [Fact]
        public static void CanCallCompressWithStringAndEncodingAndString()
        {
            // Arrange
            const string Data = "TestValue2590306";
            Encoding EncodingUsing = Encoding.UTF8;
            const string CompressorType = "TestValue1537688329";

            // Act
            var Result = Data.Compress(EncodingUsing, CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallCompressWithStringAndEncodingAndStringWithInvalidCompressorType(string? value) => "TestValue1055633683".Compress(Encoding.UTF8, value);

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallCompressWithStringAndEncodingAndStringWithInvalidData(string value) => value.Compress(Encoding.UTF8, "TestValue226606475");

        [Fact]
        public static void CanCallDecompressWithArrayOfByteAndCompressorType()
        {
            // Arrange
            var Data = new byte[] { 171, 89, 185, 167 };
            CompressorType CompressorType = CompressorType.Deflate;

            // Act
            var Result = Data.Decompress(CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Fact]
        public static void CanCallDecompressWithArrayOfByteAndString()
        {
            // Arrange
            var Data = new byte[] { 241, 127, 141, 94 };
            const string CompressorType = "TestValue744946703";

            // Act
            var Result = Data.Decompress(CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.Equal(Data, Result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallDecompressWithArrayOfByteAndStringWithInvalidCompressorType(string? value) => new byte[] { 35, 195, 149, 101 }.Decompress(value);

        [Fact]
        public static void CanCallDecompressWithStringAndEncodingAndCompressorType()
        {
            // Arrange
            Encoding EncodingUsing = Encoding.UTF8;
            CompressorType CompressorType = CompressorType.Deflate;
            var Data = "TestValue1209634736".Compress(EncodingUsing, CompressorType);

            // Act
            var Result = Data.Decompress(EncodingUsing, CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallDecompressWithStringAndEncodingAndCompressorTypeWithInvalidData(string value) => value.Decompress(Encoding.UTF8, CompressorType.Deflate);

        [Fact]
        public static void CanCallDecompressWithStringAndEncodingAndString()
        {
            // Arrange
            Encoding EncodingUsing = Encoding.UTF8;
            const string CompressorType = "TestValue16312368";
            var Data = "TestValue1209634736".Compress(EncodingUsing, CompressorType);

            // Act
            var Result = Data.Decompress(EncodingUsing, CompressorType);

            // Assert
            Assert.NotNull(Result);
            Assert.NotEmpty(Result);
            Assert.NotEqual(Data, Result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallDecompressWithStringAndEncodingAndStringWithInvalidCompressorType(string? value) => "TestValue1966726359".Compress(Encoding.UTF8, value).Decompress(Encoding.UTF8, value);

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public static void CanCallDecompressWithStringAndEncodingAndStringWithInvalidData(string value) => value.Decompress(Encoding.UTF8, "TestValue87922918");

        [Fact]
        public void DeflateTest()
        {
            const string Data = "This is a bit of data that I want to compress";
            Assert.NotEqual("This is a bit of data that I want to compress", Data.ToByteArray().Compress()?.ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.ToByteArray().Compress().Decompress()?.ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.Compress().Decompress());
        }

        [Fact]
        public void GZipTest()
        {
            const string Data = "This is a bit of data that I want to compress";
            Assert.NotEqual("This is a bit of data that I want to compress", Data.ToByteArray().Compress(CompressorType.GZip)?.ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.ToByteArray().Compress(CompressorType.GZip).Decompress(CompressorType.GZip)?.ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.Compress(compressorType: CompressorType.GZip).Decompress(compressorType: CompressorType.GZip));
        }
    }
}
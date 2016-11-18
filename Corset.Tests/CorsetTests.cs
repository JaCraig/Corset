using Corset.Default;
using Corset.Enums;
using Corset.Interfaces;
using Corset.Tests.BaseClasses;
using Corset.Tests.HelperFunctions;
using System;
using Xunit;

namespace Corset.Tests
{
    public class CorsetTests : TestBaseClass
    {
        [Fact]
        public void Compress()
        {
            var TestObject = new Corset(new ICompressor[] { new DeflateCompressor(), new GZipCompressor() });
            string Data = "This is a bit of data that I want to compress";
            Assert.Equal("CsnILFYAokSFpMwShfw0hZTEkkSFkozEEgVPhfLEvBKFknyF5PzcgqLU4mIAAAAA//8=", Convert.ToBase64String(TestObject.Compress(Data.ToByteArray(), CompressorType.Deflate)));
        }

        [Fact]
        public void Creation()
        {
            var TestObject = new Corset(new ICompressor[] { new DeflateCompressor(), new GZipCompressor() });
            Assert.NotNull(TestObject);
            Assert.Equal(2, TestObject.Compressors.Count);
        }

        [Fact]
        public void Decompress()
        {
            var TestObject = new Corset(new ICompressor[] { new DeflateCompressor(), new GZipCompressor() });
            string Data = "This is a bit of data that I want to compress";
            Assert.Equal("This is a bit of data that I want to compress", TestObject.Decompress(TestObject.Compress(Data.ToByteArray(), CompressorType.Deflate), CompressorType.Deflate).ToString(null));
        }
    }
}
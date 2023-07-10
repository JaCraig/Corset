using Corset.Default;
using Corset.Tests.BaseClasses;
using Corset.Tests.HelperFunctions;
using System;
using Xunit;

namespace Corset.Tests.Default
{
    public class GZipCompressorTests : TestBaseClass<GZipCompressor>
    {
        [Fact]
        public void Compress()
        {
            var TestObject = new GZipCompressor();
            const string Data = "This is a bit of data that I want to compress";
            var Result = Convert.ToBase64String(TestObject.Compress(Data.ToByteArray()));
            Assert.True("H4sIAAAAAAAACgrJyCxWAKJEhaTMEoX8NIWUxJJEhZKMxBIFT4XyxLwShZJ8heT83IKi1OJiAAAAAP//" == Result || "H4sIAAAAAAAAAgrJyCxWAKJEhaTMEoX8NIWUxJJEhZKMxBIFT4XyxLwShZJ8heT83IKi1OJiAAAAAP//" == Result);
        }

        [Fact]
        public void Create()
        {
            var TestObject = new GZipCompressor();
            Assert.Equal("GZip", TestObject.Name);
        }

        [Fact]
        public void Decompress()
        {
            var TestObject = new GZipCompressor();
            const string Data = "This is a bit of data that I want to compress";
            Assert.Equal("This is a bit of data that I want to compress", TestObject.Decompress(TestObject.Compress(Data.ToByteArray())).ToString(null));
        }
    }
}
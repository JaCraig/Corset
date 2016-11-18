using Corset.Enums;
using Corset.Tests.BaseClasses;
using Corset.Tests.HelperFunctions;
using Xunit;

namespace Corset.Tests
{
    public class ExtensionMethods : TestBaseClass
    {
        [Fact]
        public void DeflateTest()
        {
            string Data = "This is a bit of data that I want to compress";
            Assert.NotEqual("This is a bit of data that I want to compress", Data.ToByteArray().Compress().ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.ToByteArray().Compress().Decompress().ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.Compress().Decompress());
        }

        [Fact]
        public void GZipTest()
        {
            string Data = "This is a bit of data that I want to compress";
            Assert.NotEqual("This is a bit of data that I want to compress", Data.ToByteArray().Compress(CompressorType.GZip).ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.ToByteArray().Compress(CompressorType.GZip).Decompress(CompressorType.GZip).ToString(null));
            Assert.Equal("This is a bit of data that I want to compress", Data.Compress(compressorType: CompressorType.GZip).Decompress(compressorType: CompressorType.GZip));
        }
    }
}
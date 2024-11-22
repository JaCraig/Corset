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
            Assert.Contains(Result, new string[] { "H4sIAAAAAAAAAwrJyCxWyCxWSFRIyixRyE9TSEksSVQoyUgsUfBUKE/MK1EoyVdIzs8tKEotLgYAAAD//w==", "H4sIAAAAAAAACgrJyCxWyCxWSFRIyixRyE9TSEksSVQoyUgsUfBUKE/MK1EoyVdIzs8tKEotLgYAAAD//w==", "H4sIAAAAAAAACgrJyCxWAKJEhaTMEoX8NIWUxJJEhZKMxBIFT4XyxLwShZJ8heT83IKi1OJiAAAAAP//", "H4sIAAAAAAAAAwrJyCxWAKJEhaTMEoX8NIWUxJJEhZKMxBIFT4XyxLwShZJ8heT83IKi1OJiAAAAAP//" });
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
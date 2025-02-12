﻿using Corset.Default;
using Corset.Tests.BaseClasses;
using Corset.Tests.HelperFunctions;
using System;
using Xunit;

namespace Corset.Tests.Default
{
    public class DeflateCompressorTests : TestBaseClass<DeflateCompressor>
    {
        [Fact]
        public void Compress()
        {
            var TestObject = new DeflateCompressor();
            const string Data = "This is a bit of data that I want to compress";
            var Result = Convert.ToBase64String(TestObject.Compress(Data.ToByteArray()));
            Assert.Contains(Result, new string[] { "CsnILFbILFZIVEjKLFHIT1NISSxJVCjJSCxR8FQoT8wrUSjJV0jOzy0oSi0uBgAAAP//", "CsnILFYAokSFpMwShfw0hZTEkkSFkozEEgVPhfLEvBKFknyF5PzcgqLU4mIAAAAA//8=" });
        }

        [Fact]
        public void Create()
        {
            var TestObject = new DeflateCompressor();
            Assert.Equal("Deflate", TestObject.Name);
        }

        [Fact]
        public void Decompress()
        {
            var TestObject = new DeflateCompressor();
            const string Data = "This is a bit of data that I want to compress";
            Assert.Equal("This is a bit of data that I want to compress", TestObject.Decompress(TestObject.Compress(Data.ToByteArray())).ToString(null));
        }
    }
}
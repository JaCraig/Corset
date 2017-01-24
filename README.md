# Corset

[![Build status](https://ci.appveyor.com/api/projects/status/a44e43tnd4cwo8i6?svg=true)](https://ci.appveyor.com/project/JaCraig/corset)

Corset is a library designed to simplify compression in .Net. By default it supports Deflate and GZip but can be expanded upon to support other types of compression.

## Basic Usage

The system relies on an IoC wrapper called [Canister](https://github.com/JaCraig/Canister). While Canister has a built in IoC container, it's purpose is to actually wrap your container of choice in a way that simplifies setup and usage for other libraries that don't want to be tied to a specific IoC container. Corset uses it to detect and pull in compression providers. As such you must set up Canister in order to use Corset:

    Canister.Builder.CreateContainer(new List<ServiceDescriptor>())
                    .RegisterCorset()
                    .Build();
	
This line is required prior to using the extension methods for the first time. Once Canister is set up, you can call the extension methods provided:

    string Data = "This is a bit of data that I want to compress";
	string CompressedBase64String = Data.Compress();
	
The Compress extension method works on both strings and byte arrays. It will also allow you to specify which Encoding the string is using. By default it assumes a UTF8 encoding but this can be set as one of the parameters. The result from the Compress function will be either a Base64 string if it was called on a string or a byte array if you called the function on a byte array.

In order to Decompress the data, you simply call the Decompress extension method:

    string CompressedData = "This is a bit of data that I want to compress".Compress();
	string DecompressedData = Data.Decompress();
	
Like the Compress extension, this method works on both strings and byte arrays. It allows you to specify which Encoding the string you want back should be in, if called on a string. By default it assumes a UTF8 encoding. The result from the Decompress function is either a string if called on a string, or a byte array if called on a byte array.

## Adding Compression Types

The system loads the compressors at the beginning when Canister is initialized. In order to add your own compression type simply implement the ICompressor interface and pass the assembly it resides in to the Canister initialization line along with the Corset assembly. You may also wish to look at the CompressorBase class as it has some of the code needed already written and just requires you to write a Stream to do the actual compression.

## Installation

The library is available via Nuget with the package name "Corset". To install it run the following command in the Package Manager Console:

Install-Package Corset

## Build Process

In order to build the library you will require the following as a minimum:

1. Visual Studio 2015 with Update 3
2. .Net Core 1.0 SDK

Other than that, just clone the project and you should be able to load the solution and build without too much effort.
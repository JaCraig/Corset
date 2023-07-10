using Microsoft.Extensions.DependencyInjection;

namespace Corset.Example
{
    /// <summary>
    /// This is a simple example of how to use Corset
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            // Set up the DI container and make sure to call AddCanisterModules() to load all of the modules that are part of Corset
            var SeviceProvider = new ServiceCollection().AddCanisterModules()?.BuildServiceProvider();

            // This is the data that we want to compress
            const string Data = "This is a bit of data that I want to compress";

            // Compress the data using the default compressor
            var CompressedData = Data.Compress();
            Console.WriteLine(CompressedData);

            // Decompress the data using the default compressor
            var DecompressedData = CompressedData.Decompress();
            Console.WriteLine(DecompressedData);
        }
    }
}
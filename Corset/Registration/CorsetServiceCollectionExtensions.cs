using Corset.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Corset.Registration
{
    /// <summary>
    /// Extension methods for configuring Corset in the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class CorsetServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Corset services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The modified <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection? AddCorset(this IServiceCollection? services)
        {
            if (services.Exists<Corset>())
                return services;
            return services?.AddAllTransient<ICompressor>()
                           ?.AddSingleton<Corset>();
        }
    }
}
using Corset.Registration;
using Corset.Tests.BaseClasses;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using Xunit;

namespace Corset.Tests.Registration
{
    public class ServiceCollectionExtensionsTests : TestBaseClass
    {
        protected override Type? ObjectType { get; set; } = typeof(ServiceCollectionExtensions);

        [Fact]
        public static void CanCallAddCorset()
        {
            // Arrange
            IServiceCollection Services = Substitute.For<IServiceCollection>();

            // Act
            IServiceCollection? Result = Services.AddCorset();

            // Assert
            Assert.NotNull(Result);
            Assert.Equal(Services, Result);
        }
    }
}
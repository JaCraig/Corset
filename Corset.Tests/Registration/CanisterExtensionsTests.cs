using Canister.Interfaces;
using Corset.Registration;
using Corset.Tests.BaseClasses;
using NSubstitute;
using System;
using Xunit;

namespace Corset.Tests.Registration
{
    public class RegistrationTests : TestBaseClass
    {
        protected override Type? ObjectType { get; set; } = typeof(CorsetRegistration);

        [Fact]
        public static void CanCallRegisterCorset()
        {
            // Arrange
            ICanisterConfiguration Bootstrapper = Substitute.For<ICanisterConfiguration>();

            // Act
            ICanisterConfiguration? Result = Bootstrapper.RegisterCorset();

            // Assert
            Assert.NotNull(Result);
        }
    }
}
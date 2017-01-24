using Corset.Registration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Corset.Tests.BaseClasses
{
    [Collection("Collection")]
    public abstract class TestBaseClass
    {
        protected TestBaseClass()
        {
            if (Canister.Builder.Bootstrapper == null)
                Canister.Builder.CreateContainer(new List<ServiceDescriptor>())
                    .RegisterCorset()
                    .Build();
        }
    }
}
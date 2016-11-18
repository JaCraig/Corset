using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Corset.Tests.BaseClasses
{
    public abstract class TestBaseClass
    {
        protected TestBaseClass()
        {
            if (Canister.Builder.Bootstrapper == null)
                Canister.Builder.CreateContainer(new List<ServiceDescriptor>(), typeof(Corset).GetTypeInfo().Assembly);
        }
    }
}
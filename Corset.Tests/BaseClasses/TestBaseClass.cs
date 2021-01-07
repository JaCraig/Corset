using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Corset.Tests.BaseClasses
{
    [Collection("Collection")]
    public abstract class TestBaseClass
    {
        protected TestBaseClass()
        {
            if (Canister.Builder.Bootstrapper == null)
            {
                new ServiceCollection().AddCanisterModules(x => x.RegisterCorset());
            }
        }
    }
}
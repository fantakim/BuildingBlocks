using Loom.BuildingBlocks.Idempotency;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatrExtensions
    {
        public static IServiceCollection AddRequestManager(this IServiceCollection services, IConfiguration configuration) => services
            .AddSingleton<IRequestManager, InMemoryRequestManager>();
    }
}

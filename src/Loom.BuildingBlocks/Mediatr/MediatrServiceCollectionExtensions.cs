using Loom.BuildingBlocks.Idempotency;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatrServiceCollectionExtensions
    {
        public static IServiceCollection AddLoomRequestManager(this IServiceCollection services, IConfiguration configuration) => services
            .AddSingleton<IRequestManager, InMemoryRequestManager>();
    }
}

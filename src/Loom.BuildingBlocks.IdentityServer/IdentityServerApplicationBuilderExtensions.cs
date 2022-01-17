using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLoomIdentityServer(this IApplicationBuilder app, IdentityServerMiddlewareOptions options = null) => app
            .UseIdentityServer(options);
    }
}

using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerServiceCollectionExtensions
    {
        public static IServiceCollection AddLoomIdentityServer(this IServiceCollection services, Action<IdentityServerOptions> setupAction = null)
        {
            // https://www.scottbrady91.com/identity-server/getting-started-with-identityserver-4
            services
                .AddIdentityServer(setupAction)
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<IdentityUser>();
                

            return services;
        }
    }
}
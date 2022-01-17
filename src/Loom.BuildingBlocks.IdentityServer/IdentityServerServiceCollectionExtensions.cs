using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerServiceCollectionExtensions
    {
        public static IServiceCollection AddLoomIdentityServer(this IServiceCollection services, Action<IdentityServerOptions> setupAction = null)
        {
            // https://www.scottbrady91.com/identity-server/getting-started-with-identityserver-4
            services
                .AddIdentityServer()
                .AddInMemoryClients(new List<Client>())
                .AddInMemoryIdentityResources(new List<IdentityResource>())
                .AddInMemoryApiResources(new List<ApiResource>())
                .AddInMemoryApiScopes(new List<ApiScope>())
                .AddTestUsers(new List<TestUser>())
                .AddDeveloperSigningCredential();
                
            return services;
        }
    }
}
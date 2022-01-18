using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServer4.Test;
using Loom.BuildingBlocks.IdentityServer.Data;
using Loom.BuildingBlocks.IdentityServer.Services;
using Loom.BuildingBlocks.IdentityServer.Stores;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerServiceCollectionExtensions
    {
        public static IServiceCollection AddLoomIdentityServerWithInMemory(this IServiceCollection services, 
            IEnumerable<Client> clients = null, 
            IEnumerable<IdentityResource> identityResources = null, 
            IEnumerable<ApiResource> apiResources = null,
            IEnumerable<ApiScope> apiScopes = null,
            IEnumerable<TestUser> users = null
            )
        {
            // https://www.scottbrady91.com/identity-server/getting-started-with-identityserver-4
            services
                .AddIdentityServer()
                .AddInMemoryClients(clients)
                .AddInMemoryIdentityResources(identityResources)
                .AddInMemoryApiResources(apiResources)
                .AddInMemoryApiScopes(apiScopes)
                .AddTestUsers(users.ToList())
                .AddDeveloperSigningCredential();
                
            return services;
        }

        public static IServiceCollection AddLoomIdentityServerWithEf(this IServiceCollection services)
        {
            // https://www.jerriepelser.com/blog/resolve-dbcontext-as-interface-in-aspnet5-ioc-container/
            services
                .AddIdentityServer(options =>
                {
                    options.Caching.ClientStoreExpiration = TimeSpan.FromMinutes(30);
                    options.Caching.CorsExpiration = TimeSpan.FromMinutes(30);
                    options.Caching.ResourceStoreExpiration = TimeSpan.FromMinutes(30);
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                    options.Endpoints.EnableIntrospectionEndpoint = true;
                })
                .AddInMemoryCaching()
                .AddResourceStoreCache<ResourceStore>()
                .AddPersistedGrantStore<PersistedGrantStore>()
                .AddCorsPolicyCache<CorsPolicyService>()
                .AddClientStoreCache<ClientStore>()
                .AddDeveloperSigningCredential();

            return services;
        }
    }
}
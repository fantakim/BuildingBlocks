using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

namespace Loom.BuildingBlocks.IdentityServer.Data
{
    public interface IIdentityDbContext
    {
        DbSet<ApiScope> ApiScopes { get; set; }
        DbSet<ApiResource> ApiResources { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<IdentityResource> IdentityResources { get; set; }
        DbSet<PersistedGrant> PersistedGrants { get; set; }
    }
}

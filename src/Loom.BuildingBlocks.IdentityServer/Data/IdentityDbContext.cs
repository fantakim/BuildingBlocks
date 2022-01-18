using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loom.BuildingBlocks.IdentityServer.Data
{
    public class IdentityDbContext : IIdentityDbContext
    {
        public DbSet<ApiScope> ApiScopes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ApiResource> ApiResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Client> Clients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<IdentityResource> IdentityResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<PersistedGrant> PersistedGrants { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

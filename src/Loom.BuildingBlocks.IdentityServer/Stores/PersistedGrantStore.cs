using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loom.BuildingBlocks.IdentityServer.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            throw new NotImplementedException();
        }
    }
}

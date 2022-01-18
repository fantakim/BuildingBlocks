using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loom.BuildingBlocks.IdentityServer.Services
{
    public class CorsPolicyService : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            throw new NotImplementedException();
        }
    }
}

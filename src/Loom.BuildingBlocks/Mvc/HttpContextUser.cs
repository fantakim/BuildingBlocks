using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Loom.BuildingBlocks.Mvc
{
    public class HttpContextUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Id => _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "sub").Value;
        public string Name => _httpContextAccessor.HttpContext.User.Identity.Name;
        public IEnumerable<Claim> Claims => _httpContextAccessor.HttpContext.User.Claims;
    }
}

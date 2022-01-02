using System.Reflection;

namespace Loom.BuildingBlocks
{
    public interface IApiInfo
    {
        string AuthenticationAuthority { get; }
        string JwtBearerAudience { get; }
        string Code { get; }
        string Title { get; }
        string Version { get; }
        Assembly ApplicationAssembly { get; }
        SwaggerAuthInfo SwaggerAuthInfo { get; }
        IDictionary<string, string> Scopes { get; }
    }

    public class SwaggerAuthInfo
    {
        public string ClientId { get; }
        public string Secret { get; }
        public string Realm { get; }

        public SwaggerAuthInfo(string clientId, string secret, string realm)
        {
            ClientId = clientId;
            Secret = secret;
            Realm = realm;
        }
    }
}
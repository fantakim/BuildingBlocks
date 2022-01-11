using System.Reflection;

namespace Loom.BuildingBlocks
{
    public interface IApiInfo
    {
        string Title { get; }
        string Version { get; }
        string Authority { get; }
        string Audience { get; }
        bool RequireHttpsMetadata { get; }
        string SwaggerClientId { get; }
        string SwaggerClientSecret { get; }
        IDictionary<string, string> Scopes { get; }
        Assembly ApplicationAssembly { get; }
    }
}
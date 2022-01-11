using System.Reflection;

namespace Loom.BuildingBlocks.Sample
{
    public class ApiInfo : IApiInfo
    {
        public static IApiInfo Instance { get; private set; }
        public static IApiInfo Instantiate(IConfiguration configuration)
        {
            Instance = new ApiInfo(configuration);

            return Instance;
        }

        public ApiInfo(IConfiguration configuration)
        {
            Title = configuration["Title"];
            Version = configuration["Version"];
            Authority = configuration["AuthServer:Authority"];
            Audience = configuration["AuthServer:Audience"];
            SwaggerClientId = configuration["AuthServer:SwaggerClientId"];
            SwaggerClientSecret = configuration["AuthServer:SwaggerClientSecret"];
            RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
        }

        public string Title { get; }

        public string Version { get; }

        public string Authority { get; }

        public string Audience { get; }

        public string SwaggerClientId { get; }

        public string SwaggerClientSecret { get; }

        public bool RequireHttpsMetadata { get; }

        public IDictionary<string, string> Scopes => new Dictionary<string, string> { { "sample-api", Title } };

        public Assembly ApplicationAssembly => GetType().Assembly;
    }
}

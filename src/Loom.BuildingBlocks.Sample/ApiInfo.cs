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
            AuthenticationAuthority = configuration["AuthenticationAuthority"];
        }

        public string AuthenticationAuthority { get; }

        public string JwtBearerAudience => "sample-api";

        public string Code => "sample-api";

        public string Title => "Sample API";

        public string Version => "v1";

        public Assembly ApplicationAssembly => GetType().Assembly;

        public SwaggerAuthInfo SwaggerAuthInfo => new SwaggerAuthInfo("sample-swagger-ui", "", "");

        public IDictionary<string, string> Scopes => new Dictionary<string, string> { { "sample-api", Title } };
    }
}

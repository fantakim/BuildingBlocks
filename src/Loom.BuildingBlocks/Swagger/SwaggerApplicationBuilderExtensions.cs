using Loom.BuildingBlocks;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IApiInfo apiInfo, Action<SwaggerUIOptions> setupAction = null) => app
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.DocumentTitle = apiInfo.Title;
                options.SwaggerEndpoint($"/swagger/{apiInfo.Version}/swagger.json", $"{apiInfo.Title} {apiInfo.Version}");

                if (apiInfo.Authority != null)
                {
                    options.OAuthClientId(apiInfo.SwaggerClientId);
                    options.OAuthClientSecret(apiInfo.SwaggerClientSecret);
                    options.OAuthAppName($"{apiInfo.Title} - ${apiInfo.Version} - Swagger UI");
                    options.RoutePrefix = string.Empty;
                }
            });
    }
}

using Loom.BuildingBlocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IApiInfo apiInfo) => services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{apiInfo.AuthenticationAuthority}/connect/authorize"),
                            TokenUrl = new Uri($"{apiInfo.AuthenticationAuthority}/connect/token"),
                            Scopes = apiInfo.Scopes
                        }
                    }
                });
            });

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IApiInfo apiInfo) => app
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.DocumentTitle = apiInfo.Title;
                options.SwaggerEndpoint($"/swagger/{apiInfo.Version}/swagger.json", $"{apiInfo.Title} {apiInfo.Version}");

                if (apiInfo.AuthenticationAuthority != null)
                {
                    options.OAuthClientId(apiInfo.SwaggerAuthInfo.ClientId);
                    options.OAuthClientSecret(apiInfo.SwaggerAuthInfo.Secret);
                    options.OAuthRealm(apiInfo.SwaggerAuthInfo.Realm);
                    options.OAuthAppName($"{apiInfo.Title} - ${apiInfo.Version} - Swagger UI");
                    options.RoutePrefix = string.Empty;
                }
            });
    }
}

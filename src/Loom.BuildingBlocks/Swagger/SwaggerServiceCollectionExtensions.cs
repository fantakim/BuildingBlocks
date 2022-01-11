using Loom.BuildingBlocks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IApiInfo apiInfo, Action<SwaggerGenOptions> setupAction = null) => services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{apiInfo.Authority}/connect/authorize"),
                            TokenUrl = new Uri($"{apiInfo.Authority}/connect/token"),
                            Scopes = apiInfo.Scopes
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                setupAction?.Invoke(options);
            });
    }
}

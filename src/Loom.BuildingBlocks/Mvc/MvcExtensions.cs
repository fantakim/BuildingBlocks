using Loom.BuildingBlocks;
using Loom.BuildingBlocks.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvc();

            return services;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services, IApiInfo apiInfo)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = apiInfo.Authority;
                options.Audience = apiInfo.Audience;
                options.RequireHttpsMetadata = apiInfo.RequireHttpsMetadata;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, HttpContextUser>();

            return services;
        }

        public static IServiceCollection AddPermissiveCors(this IServiceCollection services) => services
            .AddCors(options =>
            {
                options.AddPolicy("PermissiveCorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

        public static IApplicationBuilder UsePermissiveCors(this IApplicationBuilder app) => app.UseCors("PermissiveCorsPolicy");
    }
}

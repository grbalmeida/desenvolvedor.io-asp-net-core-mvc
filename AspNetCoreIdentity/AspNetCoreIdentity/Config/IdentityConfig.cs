using AspNetCoreIdentity.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete"));
                options.AddPolicy("CanRead", policy => policy.Requirements.Add(new PermissionRequired("CanRead")));
                options.AddPolicy("CanWrite", policy => policy.Requirements.Add(new PermissionRequired("CanWrite")));
            });

            return services;
        }
    }
}

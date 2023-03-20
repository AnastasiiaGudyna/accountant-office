using IdentityServer.Api.Configurations;

namespace IdentityServer.Api.Extensions;

public static class IdentityServerExtensions
{
    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services,
        IWebHostEnvironment environment,
        IConfiguration configuration)
    {
        var identityServerConfig = configuration
            .GetSection(IdentityServerConfig.IdentityServerConfigName)
            .Get<IdentityServerConfig>();
        services
            .AddIdentityServer(opts =>
            {
                if(environment.IsProduction())
                {
                    opts.IssuerUri = identityServerConfig.IssuerUri;
                }
                opts.EmitStaticAudienceClaim = true;
                opts.Authentication.CookieLifetime = TimeSpan.FromHours(1);
                opts.Authentication.CookieSlidingExpiration = false;
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients(identityServerConfig.ClientBaseUri))
            .AddInMemoryApiScopes(Config.GetApiScopes())
            .AddTestUsers(TestUsers.Users);
        return services;
    }
}
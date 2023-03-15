namespace IdentityServer.Api.Extensions;

public static class IdentityServerExtensions
{
    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services,
        IConfiguration configuration)
    {
        var clientBaseUrl = configuration["ClientBaseUrl"];
        services
            .AddIdentityServer(opts =>
            {
                //opts.EmitStaticAudienceClaim = true;
                opts.Authentication.CookieLifetime = TimeSpan.FromHours(1);
                opts.Authentication.CookieSlidingExpiration = false;
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients(clientBaseUrl))
            .AddInMemoryApiScopes(Config.GetApiScopes())
            .AddTestUsers(TestUsers.Users);
        return services;
    }
}
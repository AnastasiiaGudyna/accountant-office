namespace IdentityServer.Api.Extensions;

public static class IdentityServerExtensions
{
    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services)
    {
        services
            .AddIdentityServer(opts =>
            {
                opts.EmitStaticAudienceClaim = true;
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients())
            .AddInMemoryApiScopes(Config.GetApiScopes());
        return services;
    }
}
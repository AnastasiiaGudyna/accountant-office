using Duende.IdentityServer.Stores;
using IdentityServer.Api.Configurations;
using IdentityServer.Api.Services;
using IdentityServer.Data.ConfigurationStores;
using IdentityServer.Data.Models;
using IdentityServer.Data.OperationalStores;
using Microsoft.AspNetCore.Identity;

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
        var builder = services
            .AddIdentityServer(opts =>
            {
                if (environment.IsProduction())
                {
                    opts.IssuerUri = identityServerConfig.IssuerUri;
                }

                opts.EmitStaticAudienceClaim = true;
                opts.Authentication.CookieLifetime = TimeSpan.FromHours(1);
                opts.Authentication.CookieSlidingExpiration = false;
            });
        AddInMemoryStores(builder, identityServerConfig);
        builder.AddSigningKeyStore<SigningKeyStore>();
        builder.AddPersistedGrantStore<PersistedGrantStore>();
        AddUserInteractionConfiguration(services, builder);
        //AddRemoteStores(services, builder);

        return services;
    }

    private static void AddInMemoryStores(IIdentityServerBuilder builder, IdentityServerConfig? identityServerConfig)
    {
        builder
            //.AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients(identityServerConfig.ClientBaseUri))
            .AddInMemoryApiScopes(Config.GetApiScopes());
    }

    private static void AddUserInteractionConfiguration(IServiceCollection services, IIdentityServerBuilder builder)
    {
        //builder.AddTestUsers(TestUsers.Users);

        builder.AddProfileService<UserProfileService>();
        services
            .AddScoped<UserStore>()
            .AddScoped<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddScoped<UserService>();
    }

    private static IServiceCollection AddRemoteStores(IServiceCollection services, IIdentityServerBuilder builder)
    {
        builder
            .AddCorsPolicyService<CorsPolicyService>()
            //configuration stores
            .AddClientStore<ClientStore>()
            .AddResourceStore<ResourceStore>()
            .AddIdentityProviderStore<AddIdentityProviderStore>()

            //Server Side Sessions
            .AddServerSideSessions()
            .AddServerSideSessionStore<ServerSideSessionStore>();

        //custom grant stores
        services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();
        services.AddTransient<IDeviceFlowStore, DeviceFlowStore>();
        return services;
    }
}
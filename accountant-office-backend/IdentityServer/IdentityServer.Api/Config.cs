using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer.Api;

public static class Config
{
    public static IEnumerable<Client> GetClients(string clientBaseUrl)
    {
        return new List<Client>
        {
            new()
            {
                ClientName = "Accountant Office Web",
                ClientId = "aow0001",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,

                // secret for authentication
                ClientSecrets = { new Secret("secret".Sha256()) },
                RedirectUris = { clientBaseUrl + "/signin-callback" },
                PostLogoutRedirectUris = { clientBaseUrl },
                // scopes that client has access to
                AllowedScopes =
                {
                    "accountant_office.read",
                    "accountant_office.write",
                    "accountant_office.delete",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OfflineAccess
                },
                AllowOfflineAccess = true,
                IdentityTokenLifetime = 450,
                AllowedCorsOrigins = new List<string> { clientBaseUrl }
            }
        };
    }

    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ("accountant_office", "Accountant Office API")
            {
                Scopes = { "accountant_office.read", "accountant_office.write, accountant_office.delete", "admin" }
            }
        };

    public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new (name: "accountant_office.read",   displayName: "Read data of Accountant Office API."),
            new (name: "accountant_office.write",  displayName: "Write data of Accountant Office API."),
            new (name: "accountant_office.delete", displayName: "Delete data of Accountant Office API."),
            new (name: "admin",                    displayName: "Administration rights.")
        };
    
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
}
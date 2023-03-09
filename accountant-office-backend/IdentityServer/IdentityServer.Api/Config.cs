using Duende.IdentityServer.Models;

namespace IdentityServer.Api;

public static class Config
{
    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new ()
            {
                ClientName = "Accountant Office Web",
                ClientId = "aow0001",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets = { new Secret("secret".Sha256()) },

                // scopes that client has access to
                AllowedScopes = { "accountant_office.read", "accountant_office.write", "accountant_office.delete" }
            }
        };
    
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
            new (
                name: "profile",
                userClaims: new[] { "name", "surname", "email" },
                displayName: "Your profile data")
        };
}
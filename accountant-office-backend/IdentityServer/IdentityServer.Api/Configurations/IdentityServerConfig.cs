namespace IdentityServer.Api.Configurations;

public class IdentityServerConfig
{
    public const string IdentityServerConfigName = "IdentityServerConfig";
    public string ClientBaseUri { get; set; }
    public string IssuerUri { get; set; }
}
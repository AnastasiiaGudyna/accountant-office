namespace IdentityServer.Data.Models;

public class Key : Entity
{
    public string Use { get; set; }
    public int Version { get; set; }
    public string Algorithm { get; set; }
    public string Data { get; set; }
    public bool DataProtected { get; set; }
    public bool IsX509Certificate { get; set; }
}
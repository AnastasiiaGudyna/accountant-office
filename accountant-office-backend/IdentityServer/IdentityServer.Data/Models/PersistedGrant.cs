namespace IdentityServer.Data.Models;

/// <summary>
/// A model for a persisted grant
/// </summary>
public class PersistedGrant : Entity
{
    public string Key { get; set; }
    public string Type { get; set; }
    public string SubjectId { get; set; }
    public string SessionId { get; set; }
    public string ClientId { get; set; }
    public string? Description { get; set; }
    public DateTime? Expiration { get; set; }
    public DateTime? ConsumedTime { get; set; }
    public string Data { get; set; }
}
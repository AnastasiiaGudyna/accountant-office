namespace IdentityServer.Data.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
}
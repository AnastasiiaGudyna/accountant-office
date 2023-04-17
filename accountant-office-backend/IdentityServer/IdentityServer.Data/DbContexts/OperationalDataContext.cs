using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data.DbContexts;

public class OperationalDataContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Key> Keys { get; set; }
    public DbSet<PersistedGrant> PersistedGrants { get; set; }
    
    public OperationalDataContext(DbContextOptions<OperationalDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OperationalDataContext).Assembly);
    }
}
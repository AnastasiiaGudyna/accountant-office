using IdentityServer.Data.Models;
using IdentityServer.Data.OperationalStores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Data.DbContexts.Configurations;

public class PersistedGrantEntityTypeConfiguration : BaseEntityTypeConfiguration<PersistedGrant>
{
    public PersistedGrantEntityTypeConfiguration() : base("persisted_grant") { }
    protected override void ConfigureChild(EntityTypeBuilder<PersistedGrant> builder)
    {
        builder
            .Property(e => e.Key)
            .IsRequired()
            .HasColumnName("key");
        builder
            .Property(e => e.Type)
            .IsRequired()
            .HasColumnName("type");
        builder
            .Property(e => e.SubjectId)
            .IsRequired()
            .HasColumnName("subject_id");
        builder
            .Property(e => e.SessionId)
            .IsRequired()
            .HasColumnName("session_id");
        builder
            .Property(e => e.ClientId)
            .IsRequired()
            .HasColumnName("client_id");
        builder
            .Property(e => e.Description)
            .HasColumnName("description");
        builder
            .Property(e => e.Expiration)
            .HasColumnName("expiry_date");
        builder
            .Property(e => e.ConsumedTime)
            .HasColumnName("consumed_date");
        builder
            .Property(e => e.Data)
            .IsRequired()
            .HasColumnName("data");
    }
}
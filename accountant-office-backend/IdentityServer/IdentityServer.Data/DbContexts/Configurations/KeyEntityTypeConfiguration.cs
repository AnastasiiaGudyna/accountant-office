using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Data.DbContexts.Configurations;

public class KeyEntityTypeConfiguration : BaseEntityTypeConfiguration<Key>
{
    public KeyEntityTypeConfiguration() : base("key") { }
    protected override void ConfigureChild(EntityTypeBuilder<Key> builder)
    {
        builder
            .Property(e => e.Use)
            .IsRequired()
            .HasColumnName("use");
        builder
            .Property(e => e.Version)
            .IsRequired()
            .HasColumnName("version");
        builder
            .Property(e => e.Algorithm)
            .IsRequired()
            .HasColumnName("algorithm");
        builder
            .Property(e => e.Data)
            .IsRequired()
            .HasColumnName("data");
        builder
            .Property(e => e.DataProtected)
            .HasColumnName("data_protected");
        builder
            .Property(e => e.IsX509Certificate)
            .HasColumnName("is_x509_certificate");
    }
}
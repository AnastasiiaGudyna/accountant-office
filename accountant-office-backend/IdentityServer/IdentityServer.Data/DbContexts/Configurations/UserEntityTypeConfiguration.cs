using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Data.DbContexts.Configurations;

public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
{
    public UserEntityTypeConfiguration() : base("registered_user")
    {
    }

    protected override void ConfigureChild(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(e => e.PasswordHash)
            .IsRequired()
            .HasColumnName("password_hash");
        builder
            .Property(e => e.Email)
            .IsRequired()
            .HasColumnName("email");
        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasColumnName("first_name");
        builder
            .Property(e => e.LastName)
            .IsRequired()
            .HasColumnName("last_name");
        builder
            .Property(e => e.Phone)
            .HasColumnName("phone");
    }
}
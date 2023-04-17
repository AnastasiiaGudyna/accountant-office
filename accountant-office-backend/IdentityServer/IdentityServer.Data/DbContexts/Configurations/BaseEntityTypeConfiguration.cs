using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Data.DbContexts.Configurations;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    protected string TableName;

    protected BaseEntityTypeConfiguration(string tableName)
    {
        TableName = tableName;
    }

    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .ToTable(TableName);
        builder
            .Property(e => e.Id)
            .HasColumnName("id");
        builder
            .Property(e => e.CreateDate)
            .HasColumnName("create_date")
            .IsRequired();
        ConfigureChild(builder);
    }

    protected abstract void ConfigureChild(EntityTypeBuilder<T> builder);
}
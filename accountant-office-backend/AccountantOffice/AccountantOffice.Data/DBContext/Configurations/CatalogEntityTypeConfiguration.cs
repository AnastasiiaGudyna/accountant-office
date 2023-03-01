using AccountantOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountantOffice.Data.DBContext.Configurations;

public class CatalogEntityTypeConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        builder
            .ToTable("catalog");
        builder
            .Property(e => e.Id)
            .HasColumnName("id");
        builder
            .Property(e => e.CreateDate)
            .HasColumnName("create_date")
            .IsRequired();
        builder
            .Property(e => e.CatalogName)
            .IsRequired()
            .HasColumnName("catalog_name");
    }
}
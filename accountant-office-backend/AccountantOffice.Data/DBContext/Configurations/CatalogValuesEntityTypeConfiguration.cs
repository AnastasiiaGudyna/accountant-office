using AccountantOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountantOffice.Data.DBContext.Configurations;

public class CatalogValuesEntityTypeConfiguration : IEntityTypeConfiguration<CatalogValues>
{
    public void Configure(EntityTypeBuilder<CatalogValues> builder)
    {
        builder
            .ToTable("catalog_values");
        builder
            .Property(e => e.Id)
            .HasColumnName("id");
        builder
            .Property(e => e.CreateDate)
            .HasColumnName("create_date")
            .IsRequired();
        builder
            .Property(e => e.Value)
            .IsRequired()
            .HasColumnName("catalog_value");
        builder
            .Property(e => e.CatalogId)
            .IsRequired()
            .HasColumnName("catalog_id");
        builder
            .HasOne(e => e.Catalog)
            .WithMany(c => c.CatalogValues)
            .HasForeignKey(e => e.CatalogId);
    }
}
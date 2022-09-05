using AccountantOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountantOffice.Data.DBContext.Configurations;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .ToTable("department");
        builder
            .Property(d => d.Id)
            .HasColumnName("id");
        builder
            .HasKey(d => d.Id);
        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasColumnName("name");
        builder
            .Property(d => d.CreateDate)
            .HasColumnName("create_date")
            .IsRequired();
    }
}
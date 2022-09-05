using AccountantOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountantOffice.Data.DBContext.Configurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("employee");
        builder
            .Property(e => e.Id)
            .HasColumnName("id");
        builder
            .Property(e => e.CreateDate)
            .HasColumnName("create_date")
            .IsRequired();
        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasColumnName("name");
        builder
            .Property(e => e.Surname)
            .IsRequired()
            .HasColumnName("surname");
        builder
            .Property(e => e.Salary)
            .IsRequired()
            .HasColumnName("salary");
        builder
            .Property(e => e.Phone)
            .HasColumnName("phone");
        builder
            .Property(e => e.DepartmentId)
            .HasColumnName("department_id");
        builder
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);
    }
}
using AccountantOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountantOffice.Data.DBContext;

public class AccountantContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CatalogValues> CatalogValues { get; set; }
        
    public AccountantContext(DbContextOptions<AccountantContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountantContext).Assembly);
            
        // modelBuilder.Entity<Department>()
        //     .ToTable("department");
        // modelBuilder.Entity<Department>()
        //     .Property(d => d.Id)
        //     .HasColumnName("id");
        // modelBuilder.Entity<Department>()
        //     .HasKey(d => d.Id);
        // modelBuilder.Entity<Department>()
        //     .Property(d => d.Name)
        //     .IsRequired()
        //     .HasColumnName("name");
        // modelBuilder.Entity<Department>()
        //     .Property(d => d.CreateDate)
        //     .HasColumnName("create_date")
        //     .IsRequired();
        //
        // modelBuilder.Entity<Employee>()
        //     .ToTable("employee");
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.Id)
        //     .HasColumnName("id");
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.CreateDate)
        //     .HasColumnName("create_date")
        //     .IsRequired();
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.Name)
        //     .IsRequired()
        //     .HasColumnName("name");
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.Surname)
        //     .IsRequired()
        //     .HasColumnName("surname");
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.Salary)
        //     .IsRequired()
        //     .HasColumnName("salary");
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.Phone)
        //     .HasColumnName("phone");
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.DepartmentId)
        //     .HasColumnName("department_id");
        // modelBuilder.Entity<Employee>()
        //     .HasOne(e => e.Department)
        //     .WithMany(d => d.Employees)
        //     .HasForeignKey(e => e.DepartmentId);
    }
}
using AccountantOffice.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountantOffice.Data.DBContext
{
    public class AccountantContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        public AccountantContext(DbContextOptions<AccountantContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Department>()
                .Property(d => d.CreateDate)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
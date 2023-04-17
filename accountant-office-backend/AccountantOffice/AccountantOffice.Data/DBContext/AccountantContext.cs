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
    }
}
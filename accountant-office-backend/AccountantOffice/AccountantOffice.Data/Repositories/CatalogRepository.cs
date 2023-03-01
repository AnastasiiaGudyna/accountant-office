using System;
using System.Linq;
using System.Threading.Tasks;
using AccountantOffice.Core.Entities;
using AccountantOffice.Data.DBContext;
using AccountantOffice.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountantOffice.Data.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly AccountantContext context;

    public CatalogRepository(AccountantContext context)
    {
        this.context = context;
    }
    
    public async Task<Catalog> GetCatalogAsync(string name)
    {
        return await context.Catalogs.FirstAsync(c => c.CatalogName == name);
    }
    
    public async Task<Catalog> GetCatalogAsync(Guid id)
    {
        return await context.Catalogs.FindAsync(id);
    }

    public async Task<Guid> CreateItemAsync(CatalogValues item)
    {
        item.CreateDate = DateTime.UtcNow;
        var entry = context.CatalogValues.Add(item);
        await context.SaveChangesAsync();
        return entry.Entity.Id;
    }
    
    public async Task<Guid> DeleteItemAsync(CatalogValues item)
    {
        var entry = context.CatalogValues.Remove(item);
        await context.SaveChangesAsync();
        return entry.Entity.Id;
    }
    
    public async Task<CatalogValues> GetCatalogValueAsync(Guid id)
    {
        return await context.CatalogValues.FindAsync(id);
    }

    public IQueryable<Catalog> GetCatalogs()
    {
        return context.Catalogs;
    }
}
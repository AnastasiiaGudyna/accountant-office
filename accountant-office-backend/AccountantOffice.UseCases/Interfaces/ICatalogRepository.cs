using System;
using System.Linq;
using System.Threading.Tasks;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Interfaces;

public interface ICatalogRepository
{
    Task<Catalog> GetCatalogAsync(string name);
    Task<Catalog> GetCatalogAsync(Guid id);
    Task<Guid> CreateItemAsync(CatalogValues item);
    Task<Guid> DeleteItemAsync(CatalogValues item);
    Task<CatalogValues> GetCatalogValueAsync(Guid id);
    IQueryable<Catalog> GetCatalogs();
}
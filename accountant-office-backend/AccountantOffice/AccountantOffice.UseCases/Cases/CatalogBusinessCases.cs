using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace AccountantOffice.UseCases.Cases
{
    public class CatalogBusinessCases
    {
        private readonly ICatalogRepository repo;
        private readonly IMapper mapper;

        public CatalogBusinessCases(ICatalogRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IEnumerable<CatalogModel> GetCatalogs()
        {
            return mapper.ProjectTo<CatalogModel>(repo.GetCatalogs());
        }

        public async Task<CatalogModel> GetCatalogAsync(Guid catalogId)
        {
            var catalog = await repo.GetCatalogAsync(catalogId);
            return mapper.Map<CatalogModel>(catalog);
        }

        public async Task<Guid> CreateAsync(Guid catalogId, CatalogValueModel item)
        {
            var catalogValue = new CatalogValues
            {
                Value = item.Value,
                Catalog = await repo.GetCatalogAsync(catalogId)
            };
            
            return await repo.CreateItemAsync(catalogValue);
        }

        public async Task<Guid> DeleteAsync(Guid catalogId, Guid id)
        {
            var item = await repo.GetCatalogValueAsync(id);
            if (item.CatalogId != catalogId)
            {
                throw new Exception("Incorrect catalog for deletion");
            }
            //check that nothing is related to this category
            return await repo.DeleteItemAsync(item);
        }

        public async Task<IEnumerable<string>> GetCatalogValuesAsync(Guid catalogId)
        {
            var catalog = await repo.GetCatalogAsync(catalogId);
            return catalog.CatalogValues.Select(cv => cv.Value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

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

        public async Task<IEnumerable<JobCategoryModel>> GetJobCategoriesAsync()
        {
            var catalog = await repo.GetCatalogAsync("Job Categories");
            return mapper.ProjectTo<JobCategoryModel>(catalog.CatalogValues.AsQueryable());
        }

        public async Task<Guid> CreateAsync(CreateJobCategoryModel item)
        {
            var catalogValue = mapper.Map<CatalogValues>(item);
            var catalog = await repo.GetCatalogAsync("Job Categories");
            catalogValue.Catalog = catalog;
            return await repo.CreateItemAsync(catalogValue);
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var item = await repo.GetCatalogValueAsync(id);
            //check that nothing is related to this category
            return await repo.DeleteItemAsync(item);
        }
    }
}
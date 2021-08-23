using System;
using System.Collections.Generic;
using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.Cases
{
    public class CatalogBusinessCases
    {
        private readonly IRepository<JobCategory> repo;
        private readonly IMapper mapper;

        public CatalogBusinessCases(IRepository<JobCategory> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IEnumerable<JobCategoryModel> GetJobCategories()
        {
            return mapper.ProjectTo<JobCategoryModel>(repo.GetList()).ToList();
        }

        public Guid Create(CreateJobCategoryModel item)
        {
            return repo.CreateItem(mapper.Map<JobCategory>(item));
        }

        public Guid Delete(Guid id)
        {
            var item = repo.GetItemById(id);
            //check that nothing is related to this category
            return repo.DeleteItem(item);
        }
    }
}
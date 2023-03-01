using System;
using System.Collections.Generic;
using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.Cases;

public class DepartmentBusinessCases : IDepartmentBusinessCases
{
    private readonly IRepository<Department> repo;
    private readonly IMapper mapper;

    public DepartmentBusinessCases(IRepository<Department> repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }

    public IEnumerable<DepartmentModel> GetDepartments(int page, int items)
    {
        var departments = repo
            .GetList(page, items);
        return mapper.ProjectTo<DepartmentModel>(departments).ToList();
    }

    public DepartmentModel Get(Guid id)
    {
        return mapper.Map<DepartmentModel>(repo.GetItemById(id));
    }

    public Guid Create(CreateDepartmentModel item)
    {
        var createDepartmentEntity = mapper.Map<Department>(item);
        return repo.CreateItem(createDepartmentEntity);
    }

    public Guid Update(Department item)
    {
        return repo.UpdateItem(item);
    }

    public Guid Delete(Guid id)
    {
        var item = repo.GetItemById(id);
        return repo.DeleteItem(item);
    }

    public int GetDepartmentsCount()
    {
        return repo.GetList().Count();
    }
}
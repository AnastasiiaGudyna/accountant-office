using System;
using System.Collections.Generic;
using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.Cases;

public class EmployeeBusinessCases : IEmployeeBusinessCases
{
    private readonly IRepository<Employee> repo;
    private readonly IRepository<Department> depRepo;
    private readonly IMapper mapper;

    public EmployeeBusinessCases(IRepository<Employee> repo, IRepository<Department> depRepo, IMapper mapper)
    {
        this.repo = repo;
        this.depRepo = depRepo;
        this.mapper = mapper;
    }

    public IEnumerable<Employee> GetEmployees(int page, int items)
    {
        return repo.GetList(page, items).ToList();
    }
    
    public IEnumerable<EmployeeModel> GetEmployees(Guid departmentId, bool showSalary, int page, int items)
    {
        var employees = repo.GetList(e => e.DepartmentId == departmentId, page, items);
        return mapper.ProjectTo<EmployeeModel>(employees, new { showSalary });
    }
    public Employee Get(Guid id)
    {
        return repo.GetItemById(id);
    }

    public Guid Create(Employee item)
    {
        var department = depRepo.GetItemById(item.DepartmentId);
        item.Department = department;
        return repo.CreateItem(item);
    }

    public Guid Update(Employee item)
    {
        return repo.UpdateItem(item);
    }

    public Guid Delete(Guid id)
    {
        var item = repo.GetItemById(id);
        return repo.DeleteItem(item);
    }
}
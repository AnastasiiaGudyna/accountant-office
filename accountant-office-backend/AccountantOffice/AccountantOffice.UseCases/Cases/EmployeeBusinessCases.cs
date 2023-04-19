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
    private readonly IRepository<Employee> employeeRepository;
    private readonly IRepository<Department> departmentRepository;
    private readonly IMapper mapper;

    public EmployeeBusinessCases(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository, IMapper mapper)
    {
        this.employeeRepository = employeeRepository;
        this.departmentRepository = departmentRepository;
        this.mapper = mapper;
    }

    public IEnumerable<Employee> GetEmployees(int page, int items)
    {
        return employeeRepository.GetList(page, items).ToList();
    }
    
    public IEnumerable<EmployeeModel> GetEmployees(Guid departmentId, bool showSalary, int page, int items)
    {
        var employees = employeeRepository.GetList(e => e.DepartmentId == departmentId, page, items);
        return mapper.ProjectTo<EmployeeModel>(employees, new { showSalary });
    }
    public Employee Get(Guid id)
    {
        return employeeRepository.GetItemById(id);
    }

    public Guid Create(Employee item)
    {
        var department = departmentRepository.GetItemById(item.DepartmentId);
        item.Department = department;
        return employeeRepository.CreateItem(item);
    }

    public Guid Update(Employee item)
    {
        return employeeRepository.UpdateItem(item);
    }

    public Guid Delete(Guid id)
    {
        var item = employeeRepository.GetItemById(id);
        return employeeRepository.DeleteItem(item);
    }
}
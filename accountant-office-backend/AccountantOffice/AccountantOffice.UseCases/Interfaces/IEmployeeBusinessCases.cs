using System;
using System.Collections.Generic;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Models;

namespace AccountantOffice.UseCases.Interfaces;

public interface IEmployeeBusinessCases
{
    IEnumerable<Employee> GetEmployees(int page, int items);
    IEnumerable<EmployeeModel> GetEmployees(Guid departmentId, int page, int items);
    Employee Get(Guid id);
    Guid Create(Employee item);
    Guid Update(Employee item);
    Guid Delete(Guid id);
}
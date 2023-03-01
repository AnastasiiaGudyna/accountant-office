using System;
using System.Collections.Generic;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Models;

namespace AccountantOffice.UseCases.Interfaces;

public interface IDepartmentBusinessCases
{
    IEnumerable<DepartmentModel> GetDepartments(int page, int items);
    DepartmentModel Get(Guid id);
    Guid Create(CreateDepartmentModel item);
    Guid Update(Department item);
    Guid Delete(Guid id);
    int GetDepartmentsCount();
}
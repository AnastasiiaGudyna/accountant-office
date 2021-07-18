using System;
using System.Collections.Generic;
using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;

namespace AccountantOffice.UseCases.Cases
{
    public class DepartmentBusinessCases
    {
        private readonly IRepository<Department> _repo;
        public DepartmentBusinessCases(IRepository<Department> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Department> GetDepartments(uint page, uint items)
        {
            return _repo
                .GetList(page, items)
                .Select(x => new Department
                {
                    AverageSalary = x.Employees.Any() ? x.Employees.Average(e => e.Salary) : 0,
                    EmployeesCount = x.Employees.Count(),
                    Name = x.Name,
                    Id = x.Id
                })
                .ToList();
        }

        public Department Get(Guid id)
        {
            return _repo.GetItemById(id);
        }

        public Guid Create(Department item)
        {
            return _repo.CreateItem(item);
        }

        public Guid Update(Department item)
        {
            return _repo.UpdateItem(item);
        }

        public Guid Delete(Guid id)
        {
            var item = _repo.GetItemById(id);
            return _repo.DeleteItem(item);
        }
    }
}
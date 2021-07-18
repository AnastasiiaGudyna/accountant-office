using System;
using System.Collections.Generic;
using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;

namespace AccountantOffice.UseCases.Cases
{
    public class EmployeeBusinessCases
    {
        private readonly IRepository<Employee> _repo;
        private readonly IRepository<Department> _depRepo;
        public EmployeeBusinessCases(IRepository<Employee> repo, IRepository<Department> depRepo)
        {
            _repo = repo;
            _depRepo = depRepo;
        }

        public IEnumerable<Employee> GetEmployees(uint page, uint items)
        {
            return _repo.GetList(page, items).ToList();
        }
    
        public IEnumerable<Employee> GetEmployees(Guid departmentId, uint page, uint items)
        {
            return _repo.GetList(e => e.DepartmentId == departmentId, page, items).ToList();
        }
        public Employee Get(Guid id)
        {
            return _repo.GetItemById(id);
        }

        public Guid Create(Employee item)
        {
            var department = _depRepo.GetItemById(item.DepartmentId);
            item.Department = department;
            return _repo.CreateItem(item);
        }

        public Guid Update(Employee item)
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
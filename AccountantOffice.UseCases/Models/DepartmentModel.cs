using System.Collections.Generic;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Models
{
    public class DepartmentModel : Entity
    {
        public string Name { get; set; }
        public float AverageSalary { get; set; }
        public int EmployeesCount { get; set; }
        public IEnumerable<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
using System;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Models
{
    public class EmployeeModel : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Salary { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
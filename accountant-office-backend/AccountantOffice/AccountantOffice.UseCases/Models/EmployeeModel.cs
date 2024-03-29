using System;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Models;

public class EmployeeModel : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Salary { get; set; }
    public Guid DepartmentId { get; set; }
}
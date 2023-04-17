using System;
using System.Collections.Generic;

namespace AccountantOffice.Core.Entities;

public class Employee : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    //public virtual IEnumerable<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
    public float Salary { get; set; }
    public virtual Department Department { get; set; }
    public Guid DepartmentId { get; set; }
}
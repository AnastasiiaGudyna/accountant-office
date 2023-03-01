using System.Collections.Generic;

namespace AccountantOffice.Core.Entities;

public class Department : Entity
{
    public string Name { get; set; }
    public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
}
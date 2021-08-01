using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountantOffice.Core.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
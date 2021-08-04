using System.Collections;
using System.Collections.Generic;

namespace AccountantOffice.Core.Entities
{
    public class JobCategory : Entity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
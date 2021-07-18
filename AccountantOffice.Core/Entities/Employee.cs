using System;
namespace AccountantOffice.Core.Entities
{

    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Salary { get; set; }
        public virtual Department Department { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
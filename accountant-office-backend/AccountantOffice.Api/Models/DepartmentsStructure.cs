using System.Collections.Generic;
using AccountantOffice.UseCases.Models;

namespace AccountantOffice.Api.Models
{
    public class DepartmentsStructure
    {
        public IEnumerable<DepartmentModel> Departments { get; set; }
        public int DepartmentsCount { get; set; }
    }
}
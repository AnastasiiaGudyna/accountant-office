using System.Collections.Generic;
using AccountantOffice.UseCases.Models;

namespace AccountantOffice.Api.Models;

/// <summary>
/// A list of requested Departments along with count in total
/// </summary>
public class DepartmentsStructure
{
    /// <summary>
    /// A list of requested Departments
    /// </summary>
    public IEnumerable<DepartmentModel> Departments { get; set; }
        
    /// <summary>
    /// Total count of Departments
    /// </summary>
    public int DepartmentsCount { get; set; }
}
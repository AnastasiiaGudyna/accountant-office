using System;
using System.Collections.Generic;
using AccountantOffice.Api.Models;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountantOffice.Api.Controllers
{
    /// <summary>
    /// Work with departments
    /// </summary>
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentBusinessCases departmentCases;
        private readonly IEmployeeBusinessCases employeeCases;

        /// <summary>
        /// Department controller constructor
        /// </summary>
        /// <param name="departmentCases">Department service inherited from <see cref="IDepartmentBusinessCases"/></param>
        /// <param name="employeeCases">Employee service inherited from <see cref="IEmployeeBusinessCases"/></param>
        public DepartmentController(IDepartmentBusinessCases departmentCases, IEmployeeBusinessCases employeeCases)
        {
            this.departmentCases = departmentCases;
            this.employeeCases = employeeCases;
        }
        
        /// <summary>
        /// Get Departments
        /// </summary>
        /// <param name="page">number of retrieving page</param>
        /// <param name="itemsOnPage">count of retrieving items</param>
        /// <returns>List of <see cref="Department"/></returns>
        [HttpGet]
        public DepartmentsStructure GetDepartments([FromQuery] int page, [FromQuery] int itemsOnPage)
        {
            var departs = new DepartmentsStructure
            {
                Departments = departmentCases.GetDepartments(page, itemsOnPage),
                DepartmentsCount = departmentCases.GetDepartmentsCount()
            };
            return departs;
        }
        
        /// <summary>
        /// Get Department by id
        /// </summary>
        /// <param name="id">Guid of department</param>
        /// <returns><see cref="DepartmentModel"/></returns>
        [HttpGet("{id:guid}")]
        public DepartmentModel Get(Guid id)
        {   
            return departmentCases.Get(id);
        }
        
        /// <summary>
        /// Create new Department
        /// </summary>
        /// <param name="item">new Department</param>
        /// <returns>id</returns>
        [HttpPut]
        public Guid Put([FromBody] CreateDepartmentModel item)
        {
            return departmentCases.Create(item);
        }

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="item">Department for update</param>
        /// <param name="id"></param>
        /// <returns>id</returns>
        [HttpPost("{id:guid}")]
        public Guid Post([FromBody] Department item, [FromRoute] Guid id)
        {
            return departmentCases.Update(item);
        }
        
        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="id">id of Department for deletion</param>
        /// <returns>id</returns>
        [HttpDelete("{id:guid}")]
        public Guid Delete([FromRoute] Guid id)
        {
            return departmentCases.Delete(id);
        }

        /// <summary>
        /// Retrieves List of employees in given department
        /// </summary>
        /// <param name="id">Department Id</param>
        /// <param name="page">Page number</param>
        /// <param name="itemsOnPage">Items on page</param>
        /// <returns>List of Employees. For more information see <see cref="IEnumerable{EmployeeModel}"/>></returns>
        [HttpGet("{id:guid}/employees")]
        public IEnumerable<EmployeeModel> GetEmployees([FromRoute] Guid id, int page, int itemsOnPage)
        {
            return employeeCases.GetEmployees(id, page, itemsOnPage);
        }
    }
}
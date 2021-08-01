using System;
using System.Collections;
using System.Collections.Generic;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Cases;
using AccountantOffice.UseCases.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountantOffice.Api.Controllers
{
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentBusinessCases departmentCases;
        private readonly EmployeeBusinessCases employeeCases;

        public DepartmentController(DepartmentBusinessCases departmentCases, EmployeeBusinessCases employeeCases)
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
        [HttpGet("")]
        public IEnumerable<DepartmentModel> GetDepartments([FromQuery] uint page, [FromQuery] uint itemsOnPage)
        {   
            return departmentCases.GetDepartments(page, itemsOnPage);
        }
        
        /// <summary>
        /// Get Department by id
        /// </summary>
        /// <param name="id">Guid of department</param>
        /// <returns><see cref="Department"/></returns>
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

        [HttpGet("{id:guid}/employees")]
        public IEnumerable<EmployeeModel> GetEmployees([FromRoute] Guid id, uint page, uint itemsOnPage)
        {
            return employeeCases.GetEmployees(id, page, itemsOnPage);
        }
    }
}
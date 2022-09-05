using System;
using System.Collections.Generic;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Cases;
using AccountantOffice.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountantOffice.Api.Controllers
{
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusinessCases cases;

        public EmployeeController(IEmployeeBusinessCases cases)
        {
            this.cases = cases;
        }
        /// <summary>
        /// Get Employees
        /// </summary>
        /// <param name="page">number of retrieving page</param>
        /// <param name="itemsOnPage">count of retrieving items</param>
        /// <returns>List of <see cref="Employee"/></returns>
        [HttpGet]
        public IEnumerable<Employee> GetEmployees([FromQuery] int page, [FromQuery] int itemsOnPage)
        {   
            return cases.GetEmployees(page, itemsOnPage);
        }
        
        /// <summary>
        /// Get Employee by id
        /// </summary>
        /// <param name="id">Guid of Employee</param>
        /// <returns><see cref="Employee"/></returns>
        [HttpGet("{id:guid}")]
        public Employee Get(Guid id)
        {   
            return cases.Get(id);
        }
        
        /// <summary>
        /// Create new Employee
        /// </summary>
        /// <param name="item">new Employee</param>
        /// <returns>Employee id</returns>
        [HttpPut]
        public Guid Put([FromBody] Employee item)
        {
            return cases.Create(item);
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="item">Employee for update</param>
        /// <param name="id"></param>
        /// <returns>Employee id</returns>
        [HttpPost("{id:guid}")]
        public Guid Post([FromBody] Employee item, [FromRoute] Guid id)
        {
            return cases.Update(item);
        }
        
        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id">id of Employee for deletion</param>
        /// <returns>Employee id</returns>
        [HttpDelete("{id:guid}")]
        public Guid Post([FromRoute] Guid id)
        {
            return cases.Delete(id);
        }
    }
}
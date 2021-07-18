using System;
using System.Collections.Generic;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Cases;
using Microsoft.AspNetCore.Mvc;

namespace AccountantOffice.Api.Controllers
{
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeBusinessCases _cases;

        public EmployeeController(EmployeeBusinessCases cases)
        {
            _cases = cases;
        }
        /// <summary>
        /// Get Employees
        /// </summary>
        /// <param name="page">number of retrieving page</param>
        /// <param name="itemsOnPage">count of retrieving items</param>
        /// <returns>List of <see cref="Employee"/></returns>
        [HttpGet("")]
        public IEnumerable<Employee> GetEmployees([FromQuery] uint page, [FromQuery] uint itemsOnPage)
        {   
            return _cases.GetEmployees(page, itemsOnPage);
        }
        
        /// <summary>
        /// Get Employee by id
        /// </summary>
        /// <param name="id">Guid of Employee</param>
        /// <returns><see cref="Employee"/></returns>
        [HttpGet("{id}")]
        public Employee Get(Guid id)
        {   
            return _cases.Get(id);
        }
        
        /// <summary>
        /// Create new Employee
        /// </summary>
        /// <param name="item">new Employee</param>
        /// <returns>id</returns>
        [HttpPut("")]
        public Guid Put([FromBody] Employee item)
        {
            return _cases.Create(item);
        }
        
        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="item">Employee for update</param>
        /// <returns>id</returns>
        [HttpPost("{id}")]
        public Guid Post([FromBody] Employee item, [FromRoute] Guid id)
        {
            return _cases.Update(item);
        }
        
        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id">id of Employee for deletion</param>
        /// <returns>id</returns>
        [HttpDelete("{id}")]
        public Guid Post([FromRoute] Guid id)
        {
            return _cases.Delete(id);
        }
    }
}
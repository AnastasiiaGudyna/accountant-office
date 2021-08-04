using System;
using System.Collections.Generic;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Cases;
using AccountantOffice.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountantOffice.Api.Controllers
{
    /// <summary>
    /// controller for different lists used in application
    /// </summary>
    [Route("catalogs")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogBusinessCases cases;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cases"></param>
        public CatalogController(CatalogBusinessCases cases)
        {
            this.cases = cases;
        }

        /// <summary>
        /// Retrieves list of job categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("job-categories")]
        public IEnumerable<JobCategoryModel> GetJobCategories()
        {
            return cases.GetJobCategories();
        }

        /// <summary>
        /// Creates job category
        /// </summary>
        /// <returns></returns>
        [HttpPut("job-categories")]
        public Guid CreateJobCategory([FromBody] JobCategory category)
        {
            return cases.Create(category);
        }

        /// <summary>
        /// Deletes job category
        /// </summary>
        /// <returns></returns>
        [HttpDelete("job-categories/{id}")]
        public Guid GetJobCategories(Guid id)
        {
            return cases.Delete(id);
        }
    }
}
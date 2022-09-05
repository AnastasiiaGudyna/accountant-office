using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public Task<IEnumerable<JobCategoryModel>> GetJobCategories()
        {
            return cases.GetJobCategoriesAsync();
        }

        /// <summary>
        /// Creates job category
        /// </summary>
        /// <returns></returns>
        [HttpPut("job-categories")]
        public Task<Guid> CreateJobCategory([FromBody] CreateJobCategoryModel category)
        {
            return cases.CreateAsync(category);
        }

        /// <summary>
        /// Deletes job category
        /// </summary>
        /// <returns></returns>
        [HttpDelete("job-categories/{id:guid}")]
        public Task<Guid> GetJobCategories(Guid id)
        {
            return cases.DeleteAsync(id);
        }

        /// <summary>
        /// Retrieves list skills
        /// </summary>
        /// <returns></returns>
        [HttpGet("skills")]
        public IEnumerable<string> GetSkills()
        {
            return new List<string>{"DB", "Java", "JavaScript"};
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountantOffice.UseCases.Cases;
using AccountantOffice.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountantOffice.Api.Controllers;

/// <summary>
/// Controller for different lists used in application
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
    /// Retrieves all catalogs
    /// </summary>
    /// <returns>List of <see cref="CatalogModel"/></returns>
    [HttpGet]
    public IEnumerable<CatalogModel> GetCatalogs()
    {
        return cases.GetCatalogs();
    }
        
    /// <summary>
    /// Retrieves catalogs with specific id
    /// </summary>
    /// <param name="catalogId">catalog id</param>
    /// <returns></returns>
    [HttpGet("{catalogId:guid}")]
    public Task<CatalogModel> GetCatalogAsync(Guid catalogId)
    {
        return cases.GetCatalogAsync(catalogId);
    }
        
    /// <summary>
    /// Retrieves catalog values
    /// </summary>
    /// <returns>catalog value id</returns>
    [HttpGet("{catalogId:guid}/catalog-value")]
    public Task<IEnumerable<string>> GetValuesAsync(Guid catalogId)
    {
        return cases.GetCatalogValuesAsync(catalogId);
    }
        
    /// <summary>
    /// Creates catalog value
    /// </summary>
    /// <returns>catalog value id</returns>
    [HttpPut("{catalogId:guid}/catalog-value")]
    public Task<Guid> CreateValueAsync(Guid catalogId, [FromBody] CatalogValueModel item)
    {
        return cases.CreateAsync(catalogId, item);
    }

    /// <summary>
    /// Deletes catalog value
    /// </summary>
    /// <returns>catalog value id</returns>
    [HttpDelete("{catalogId:guid}/catalog-value/{id:guid}")]
    public Task<Guid> DeleteValueAsync(Guid catalogId, Guid id)
    {
        return cases.DeleteAsync(catalogId, id);
    }
}
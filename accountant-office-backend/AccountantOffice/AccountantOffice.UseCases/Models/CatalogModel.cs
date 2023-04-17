using System.Collections.Generic;
using AccountantOffice.Core.Entities;

namespace AccountantOffice.UseCases.Models;

public class CatalogModel : Entity
{
    public string CatalogName { get; set; }
    public virtual IEnumerable<CatalogValueModel> CatalogValues { get; set; }
}
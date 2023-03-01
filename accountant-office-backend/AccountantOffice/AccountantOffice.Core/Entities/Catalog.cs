using System.Collections.Generic;

namespace AccountantOffice.Core.Entities;

public class Catalog : Entity
{
    public string CatalogName { get; set; }
    public virtual IEnumerable<CatalogValues> CatalogValues { get; set; }
}
using System;

namespace AccountantOffice.Core.Entities;

public class CatalogValues : Entity
{
    public string Value { get; set; }
    public virtual Catalog Catalog { get; set; }
    public Guid CatalogId { get; set; }
}
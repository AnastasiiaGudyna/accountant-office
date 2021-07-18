using System;

namespace AccountantOffice.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
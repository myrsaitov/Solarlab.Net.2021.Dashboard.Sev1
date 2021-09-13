using System;

namespace Sev1.Advertisements.Domain.Base
{
    public class EntityMutable<TId> : Entity<TId>
    {
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
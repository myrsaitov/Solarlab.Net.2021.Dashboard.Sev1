using System;

namespace Sev1.Advertisements.Domain.Shared
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
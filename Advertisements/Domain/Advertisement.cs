using System.Collections.Generic;
using sev1.Advertisements.Domain.Shared;

namespace sev1.Advertisements.Domain
{
    public class Advertisement : EntityMutable<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
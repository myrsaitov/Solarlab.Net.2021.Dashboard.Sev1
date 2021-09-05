using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sev1.Advertisements.Domain.Shared;

namespace Sev1.Advertisements.Domain
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
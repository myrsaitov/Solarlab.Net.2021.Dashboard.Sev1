using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sev1.Advertisements.Domain.Shared;

namespace Sev1.Advertisements.Domain
{
    public class Tag : Entity<int>
    {
        [MaxLength(32)]
        public string Body { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
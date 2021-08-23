using System.Collections.Generic;
using sev1.Advertisements.Domain.Shared;

namespace sev1.Advertisements.Domain
{
    public class Category : EntityMutable<int>
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<Advertisement> Contents { get; set; }
    }
}
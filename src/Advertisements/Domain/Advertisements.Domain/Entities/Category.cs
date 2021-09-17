using System.Collections.Generic;
using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain
{
    public class Category : EntityMutable<int>
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id и ссылка на родительскую категорию
        /// </summary>
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        /// <summary>
        /// Коллекция связанных подкатегорий
        /// </summary>
        public virtual ICollection<Category> ChildCategories { get; set; }

        /// <summary>
        /// Коллекция связанных объявлений
        /// </summary>
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
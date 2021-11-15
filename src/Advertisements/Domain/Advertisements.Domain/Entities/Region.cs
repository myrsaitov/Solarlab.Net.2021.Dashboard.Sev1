using System.Collections.Generic;
using Sev1.Advertisements.Domain.Base.Entities;

namespace Sev1.Advertisements.Domain
{
    /// <summary>
    /// Доменная модель региона
    /// </summary>
    public class Region : Entity<int?>
    {
        /// <summary>
        /// Текст ярлыка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Объявления, связанные с этим ярлыком
        /// </summary>
        public virtual ICollection<Advertisement> Advertisements { get; set; }

        /// <summary>
        /// Идентификатор родительского региона - округ
        /// </summary>
        public int? ParentRegionId { get; set; }

        /// <summary>
        /// Ссылка на родительский регион - округ
        /// </summary>
        public virtual Region ParentRegion { get; set; }
    }
}
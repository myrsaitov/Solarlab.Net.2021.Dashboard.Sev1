using System.Collections.Generic;
using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain
{
    public class Region : EntityMutable<int?>
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
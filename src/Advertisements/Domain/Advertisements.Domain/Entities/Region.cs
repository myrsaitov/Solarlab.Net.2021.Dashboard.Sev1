using System.Collections.Generic;
using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain
{
    public class Region : EntityMutable<string>
    {
        /// <summary>
        /// Текст ярлыка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество объявлений, связанных с этим регионом
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Объявления, связанные с этим ярлыком
        /// </summary>
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
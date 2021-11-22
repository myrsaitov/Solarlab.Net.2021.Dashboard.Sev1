using System.Collections.Generic;
using Sev1.Advertisements.Domain.Base.Entities;

namespace Sev1.Advertisements.Domain
{
    /// <summary>
    /// Доменная модель тага
    /// </summary>
    public class Tag : Entity<int?>
    {
        /// <summary>
        /// Текст ярлыка
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Объявления, связанные с этим ярлыком
        /// </summary>
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
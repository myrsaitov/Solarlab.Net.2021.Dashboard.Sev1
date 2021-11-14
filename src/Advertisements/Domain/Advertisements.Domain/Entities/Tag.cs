using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sev1.Advertisements.Domain.Base;

namespace Sev1.Advertisements.Domain
{
    public class Tag : Entity<int?>
    {
        /// <summary>
        /// Текст ярлыка
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Количество объявлений, связанных с этим ярлыком
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Объявления, связанные с этим ярлыком
        /// </summary>
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sev1.UserFiles.Domain.Base;

namespace Sev1.UserFiles.Domain
{
    public class Tag : Entity<int>
    {
        /// <summary>
        /// Текст ярлыка
        /// </summary>
        [MaxLength(32)]
        public string Body { get; set; }

        /// <summary>
        /// Количество объявлений, связанных с этим ярлыком
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Объявления, связанные с этим ярлыком
        /// </summary>
        public virtual ICollection<Advertisement> UserFiles { get; set; }
    }
}
using Comments.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.Base
{
    public class DtoBase
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        [Required]
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Id Покупателя
        /// </summary>
        public Guid ConsumerId { get; set; }

        /// <summary>
        /// Тип чата
        /// </summary>
        [Required]
        public ChatType Type { get; set; }
    }
}

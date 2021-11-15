using Comments.Contracts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestDeleteChat : DtoRequestDeleteChatBase
    {
        /// <summary>
        /// Id объявления
        /// </summary>
        [Required]
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Id Покупателя
        /// </summary>
        [Required]
        public Guid ConsumerId { get; set; }
    }
}

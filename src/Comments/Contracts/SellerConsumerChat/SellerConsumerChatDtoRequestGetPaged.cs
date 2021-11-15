using Comments.Contracts.Base;
using Comments.Contracts.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestGetPaged : DtoRequestGetPagedBase
    {
        /// <summary>
        /// Id Покупателя
        /// </summary>
        [Required]
        public Guid ConsumerId { get; set; }
    }
}

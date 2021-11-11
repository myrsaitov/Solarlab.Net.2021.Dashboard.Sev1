using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestGetUserChats
    {
        /// <summary>
        /// Id Пользователя
        /// </summary>
        [Required]
        public Guid UserId { get; set; }
    }
}

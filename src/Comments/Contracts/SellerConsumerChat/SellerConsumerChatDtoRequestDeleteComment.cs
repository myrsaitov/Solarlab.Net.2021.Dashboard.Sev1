using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestDeleteComment
    {
        /// <summary>
        /// Id Сообщения
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestUpdateComment
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        [Required]
        public Guid CommentId { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Message { get; set; }
    }
}
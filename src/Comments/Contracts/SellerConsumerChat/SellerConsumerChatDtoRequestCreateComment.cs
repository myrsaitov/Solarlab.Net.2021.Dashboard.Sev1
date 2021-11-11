using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.SellerConsumerChat
{
    public class SellerConsumerChatDtoRequestCreateComment
    {
        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        [Required]
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        [Required]
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Message { get; set; }
    }
}
